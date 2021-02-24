using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Business.BO;
using Domain.Business.Interface;
using Domain.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using DocumentManager.CrossCutting.ApplicationModel;
using DocumentManager.Areas.Providers.Models;
using Microsoft.AspNetCore.Authorization;
using DocumentManager.CrossCutting.Enumerators;
using DocumentManager.Models;
using System.Security.Cryptography;
using System.IO;
using DocumentManager.Controllers;
using Microsoft.AspNetCore.Identity;
using DocumentManager.Areas.Identity.Models;

namespace DocumentManager.Areas.Reviews.Controllers
{
    [Area("Reviews")]
    public class ReviewsController : BaseController
    {
        private readonly IDocuments docBO;
        private readonly ILogger<ReviewsController> logger;
        private readonly byte[] key = new byte[16] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };
        private readonly byte[] IV = new byte[16] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };

        public ReviewsController(DomainContext context, ILogger<ReviewsController> log, UserManager<Users> userManag, RoleManager<Role> roleManag) : base(userManag, roleManag, context)
        {
            docBO = new DocumentBO(context);
            logger = log;
        }

        [HttpGet]
        [Authorize(Roles = RolesEnum.SUPERVISOR + "," + RolesEnum.ADMIN)]
        public IActionResult Index()
        {
            List<DocumentsAM> lstDocs = docBO.Get();
            DocVM model = new DocVM { ListDocs = lstDocs };

            return View(model);
        }

        [HttpGet]
        [Authorize(Roles = RolesEnum.SUPERVISOR + "," + RolesEnum.ADMIN)]
        public IActionResult GetDocs(int id)
        {
            var response = new ResponseModel { Message = "OK", Success = true };

            try
            {
                var doc = docBO.Get(id);

                if (doc != null)
                {
                    var fileByte = Decrypt(doc.Contents, key, IV);

                    System.IO.DirectoryInfo directory = new System.IO.DirectoryInfo("wwwroot\\pdf");
                    var nameFolder = "tempFilesAbbot";
                    var folderPath = Path.Combine(directory.FullName, nameFolder);

                    string fileName = doc.Name.Replace(".pdf", "");
                    fileName += "-" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".pdf";
                    var filePath = Path.Combine(folderPath, fileName);

                    if (!Directory.Exists(folderPath))
                        Directory.CreateDirectory(folderPath);

                    using (var fs = new FileStream(filePath, FileMode.Create, FileAccess.Write))
                    {
                        fs.Write(fileByte, 0, fileByte.Length);
                        fs.Close();
                    }


                    response.Result = "/pdf/tempFilesAbbot/" + fileName;

                }

                return Json(response);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                return Json(new ResponseModel { Message = ex.Message, Success = false });

            }
        }

        #region VIEW FILE

        #region CHANGE STATE DOC
        [HttpGet]
        [Authorize(Roles = RolesEnum.SUPERVISOR + "," + RolesEnum.ADMIN)]
        public IActionResult ApproveDoc(int id)
        {
            try
            {
                var response = new ResponseModel { Message = "Documento aprovado exitosamente", Success = true };

                var doc = docBO.Get(id);
                doc.IdState = 3;
                docBO.Update(doc);

                return Json(response);

            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                return Json(new ResponseModel { Message = ex.Message, Success = false });
            }
        }

        public IActionResult RejectDoc(int id)
        {
            try
            {
                var response = new ResponseModel { Message = "Documento rechazado exitosamente", Success = true };

                var doc = docBO.Get(id);
                doc.IdState = 4;
                docBO.Update(doc);

                return Json(response);

            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                return Json(new ResponseModel { Message = ex.Message, Success = false });
            }
        }
        #endregion

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

        #endregion
    }
}
