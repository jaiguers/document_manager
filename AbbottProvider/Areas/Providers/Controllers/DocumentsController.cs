using DocumentManager.Areas.Identity.Models;
using DocumentManager.Areas.Providers.Models;
using DocumentManager.Controllers;
using DocumentManager.CrossCutting.ApplicationModel;
using DocumentManager.CrossCutting.Enumerators;
using Domain.Business.BO;
using Domain.Business.Interface;
using Domain.Context;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace DocumentManager.Areas.Providers.Controllers
{
    [Area("Providers")]
    public class DocumentsController : BaseController
    {
        private readonly ILogger<DocumentsController> logger;
        private readonly byte[] key = new byte[16] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };
        private readonly byte[] IV = new byte[16] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };

        public IConfiguration Configuration { get; }

        public DocumentsController(DomainContext context, ILogger<DocumentsController> log, UserManager<Users> userManag, RoleManager<Role> roleManag, IConfiguration configuration)
            : base(userManag, roleManag, context)
        {
            logger = log;
            Configuration = configuration;

        }

        [HttpGet]
        [Authorize(Roles = RolesEnum.PROVIDERS)]
        public async System.Threading.Tasks.Task<IActionResult> IndexAsync()
        {
            DocVM model = new DocVM();

            var apiEndpoint = Configuration["ApiEndpoint"];
            var apiClient = new HttpClient();
            string userId = HttpContext.Session.GetString("IdUsers");

            var response = apiClient.GetAsync(apiEndpoint + "/api/Docs/GetDocs/" + userId).Result;

            if (response.IsSuccessStatusCode)
            {
                var strJson = await response.Content.ReadAsStringAsync();
                var deserialize = JsonConvert.DeserializeObject<List<DocumentsAM>>(strJson);
                // model.PersonServiceList = (List<PersonServicesAM>)deserialize;
                model.ListDocs = deserialize;
            }
            return View(model);
        }

        [HttpGet]
        [Authorize(Roles = RolesEnum.PROVIDERS)]
        public async System.Threading.Tasks.Task<IActionResult> LoadDocsAsync()
        {
            var apiEndpoint = Configuration["ApiEndpoint"];
            var apiClient = new HttpClient();

            var response = apiClient.GetAsync(apiEndpoint + "/api/Docs/GetDocType/").Result;
            if (response.IsSuccessStatusCode)
            {
                var strJson = await response.Content.ReadAsStringAsync();
                var deserialize = JsonConvert.DeserializeObject<List<DocumentTypeAM>>(strJson);
                ViewBag.ListDocType = new SelectList(deserialize, "Id", "Name");
            }
            else
                ViewBag.ListDocType = new SelectList(new List<DocumentTypeAM>(), "Id", "Name");


            return View();
        }

        [HttpPost]
        [Authorize(Roles = RolesEnum.PROVIDERS)]
        public async System.Threading.Tasks.Task<IActionResult> LoadDocsAsync(DocVM model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var apiEndpoint = Configuration["ApiEndpoint"];
                    var apiClient = new HttpClient();

                    IFormFile attaCC = Request.Form.Files.Where(x => x.Name == "UploadedFile").ToList()[0];
                    System.IO.DirectoryInfo directory = new System.IO.DirectoryInfo("wwwroot\\pdf");
                    var nameFolder = "tempFilesMVM";
                    var folderPath = Path.Combine(directory.FullName, nameFolder);
                    var filePath = Path.Combine(folderPath, attaCC.FileName);

                    if (!Directory.Exists(folderPath))
                        Directory.CreateDirectory(folderPath);

                    using (var stream = new FileStream(filePath, FileMode.Create, FileAccess.Write))
                    {
                        attaCC.CopyTo(stream);
                        stream.Close();
                    }

                    var doc = UploadFile(attaCC, filePath, model.IdDocumentType);

                    HttpContent content = new StringContent(JsonConvert.SerializeObject(doc), Encoding.UTF8, "application/json");
                    var response = await apiClient.PostAsync(apiEndpoint + "/api/Docs/CreateDoc", content);

                    if (response.IsSuccessStatusCode)
                        CreateModal("exito", "Terminado", "Se ha registrado el documento satisfactoriamente.", "Terminar", null, "Redirect('Index')", null);

                    var res = apiClient.GetAsync(apiEndpoint + "/api/Docs/GetDocType/").Result;
                    if (res.IsSuccessStatusCode)
                    {
                        var strJson = await res.Content.ReadAsStringAsync();
                        var deserialize = JsonConvert.DeserializeObject<List<DocumentTypeAM>>(strJson);
                        ViewBag.ListDocType = new SelectList(deserialize, "Id", "Name");
                    }

                    return View(model);
                }
            }
            catch (Exception ex)
            {
                logger.LogInformation(ex.Message);
                CreateModal("error", "Error", "Error al cargar los documentos.", "Continuar", null, "Redirect('/Providers/Documents/Index')", null);
                return View(model);
            }

            return View(model);
        }

        #region UPLOAD FILE
        private DocumentsAM UploadFile(IFormFile formFile, string filePath, long type)
        {
            string userId = HttpContext.Session.GetString("IdUsers");
            byte[] fileByte = System.IO.File.ReadAllBytes(filePath);

            DocumentsAM doc = new DocumentsAM
            {
                Name = formFile.FileName,
                Hash = Guid.NewGuid().ToString(),
                IdUser = userId,
                Size = (formFile.Length) / 1024,
                Pages = NumberPages(filePath),
                RegistrationDate = DateTime.Now,
                IdState = 5,
                IdDocType = type
            };

            doc.Contents = Encrypt(fileByte, key, IV);

            return doc;
        }

        public byte[] Encrypt(byte[] data, byte[] key, byte[] iv)
        {
            using (var aes = Aes.Create())
            {
                aes.KeySize = 128;
                aes.BlockSize = 128;
                aes.Padding = PaddingMode.Zeros;

                aes.Key = key;
                aes.IV = iv;

                using (var encryptor = aes.CreateEncryptor(aes.Key, aes.IV))
                {
                    return PerformCryptography(data, encryptor);
                }
            }
        }

        public byte[] Decrypt(byte[] data, byte[] key, byte[] iv)
        {
            using (var aes = Aes.Create())
            {
                aes.KeySize = 128;
                aes.BlockSize = 128;
                aes.Padding = PaddingMode.Zeros;

                aes.Key = key;
                aes.IV = iv;

                using var decryptor = aes.CreateDecryptor(aes.Key, aes.IV);
                return PerformCryptography(data, decryptor);
            }
        }

        private byte[] PerformCryptography(byte[] data, ICryptoTransform cryptoTransform)
        {
            using (var ms = new MemoryStream())
            using (var cryptoStream = new CryptoStream(ms, cryptoTransform, CryptoStreamMode.Write))
            {
                cryptoStream.Write(data, 0, data.Length);
                cryptoStream.FlushFinalBlock();

                return ms.ToArray();
            }
        }
        private int NumberPages(string pathFile)
        {
            var nPaginas = 0;
            //Obtiene la cantidad de páginas del documento
            using (var fs = new FileStream(pathFile, FileMode.Open, FileAccess.Read))
            {
                using (var sr = new StreamReader(fs))
                {
                    var pdfText = sr.ReadToEnd();
                    Regex rx1 = new Regex(@"/Type\s*/Page[^s]");
                    MatchCollection matches = rx1.Matches(pdfText);
                    nPaginas = matches.Count();
                }
            }
            return nPaginas;
        }
        #endregion

    }
}
