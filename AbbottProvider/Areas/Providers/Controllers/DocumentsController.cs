using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Abbott.CrossCutting.ApplicationModel;
using Abbott.CrossCutting.Enumerators;
using AbbottProvider.Areas.Identity.Models;
using AbbottProvider.Areas.Providers.Models;
using AbbottProvider.Controllers;
using Domain.Business.BO;
using Domain.Business.Interface;
using Domain.Context;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AbbottProvider.Areas.Providers.Controllers
{
    [Area("Providers")]
    public class DocumentsController : BaseController
    {
        private readonly IDocuments docBO;
        private readonly ILogger<DocumentsController> logger;
        private readonly byte[] key = new byte[16] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };
        private readonly byte[] IV = new byte[16] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };

        public DocumentsController(DomainContext context, ILogger<DocumentsController> log, UserManager<Users> userManag, RoleManager<Role> roleManag)
            : base(userManag, roleManag, context)
        {
            logger = log;
            docBO = new DocumentBO(context);
        }

        [HttpGet]
        [Authorize(Roles = RolesEnum.PROVIDERS)]
        public IActionResult Index()
        {
            string userId = HttpContext.Session.GetString("IdUsers");

            List<DocumentsAM> lstDocs = docBO.Get(j => j.IdUser == userId);
            DocVM model = new DocVM { ListDocs = lstDocs };

            return View(model);
        }

        [HttpGet]
        [Authorize(Roles = RolesEnum.PROVIDERS)]
        public IActionResult LoadDocs()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = RolesEnum.PROVIDERS)]
        public IActionResult LoadDocs(DocVM model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    IFormFile attaCC = Request.Form.Files.Where(x => x.Name == "UploadedFileCC").ToList()[0];
                    System.IO.DirectoryInfo directory = new System.IO.DirectoryInfo("wwwroot\\pdf");
                    var nameFolder = "tempFilesAbbot";
                    var folderPath = Path.Combine(directory.FullName, nameFolder);
                    var filePath = Path.Combine(folderPath, attaCC.FileName);

                    if (!Directory.Exists(folderPath))
                        Directory.CreateDirectory(folderPath);

                    using (var stream = new FileStream(filePath, FileMode.Create, FileAccess.Write))
                    {
                        attaCC.CopyTo(stream);
                        stream.Close();
                    }

                    var doc = UploadFile(attaCC, filePath, "CC");
                    docBO.Create(doc);

                    IFormFile attaHV = Request.Form.Files.Where(x => x.Name == "UploadedFileHv").ToList()[0];
                    filePath = Path.Combine(folderPath, attaHV.FileName);

                    using (var stream = new FileStream(filePath, FileMode.Create, FileAccess.Write))
                    {
                        attaHV.CopyTo(stream);
                        stream.Close();
                    }

                    doc = UploadFile(attaHV, filePath, "HV");

                    docBO.Create(doc);

                    IFormFile attaARL = Request.Form.Files.Where(x => x.Name == "UploadedFileARL").ToList()[0];
                    filePath = Path.Combine(folderPath, attaARL.FileName);

                    using (var stream = new FileStream(filePath, FileMode.Create, FileAccess.Write))
                    {
                        attaARL.CopyTo(stream);
                        stream.Close();
                    }

                    doc = UploadFile(attaARL, filePath, "ARL");
                    docBO.Create(doc);

                    CreateModal("exito", "Terminado", "Documentos cargados exitosamente.", "Continuar", null, "Redirect('/Providers/Documents/Index')", null);
                    return View(model);
                }
            }
            catch (Exception ex)
            {
                CreateModal("error", "Error", "Error al cargar los documentos.", "Continuar", null, "Redirect('/Providers/Documents/Index')", null);
                return View(model);
            }

            return View(model);
        }

        #region UPLOAD FILE
        private DocumentsAM UploadFile(IFormFile formFile, string filePath, string type)
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
                IdState = 5
            };

            if (type.Equals("CC"))
                doc.IdDocType = 1;
            else if (type.Equals("HV"))
                doc.IdDocType = 2;
            else if (type.Equals("ARL"))
                doc.IdDocType = 4;

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
