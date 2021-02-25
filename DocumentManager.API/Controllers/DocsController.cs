using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DocumentManager.API.ApiModel;
using DocumentManager.CrossCutting.ApplicationModel;
using Domain.Business.BO;
using Domain.Business.Interface;
using Domain.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DocumentManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocsController : ControllerBase
    {
        private readonly static string INTERNAL_ERROR = "Internal server error";
        private readonly static string SUCCESFULLY = "Creado correctamente";
        private readonly ILogger<DocsController> logger;
        private readonly IDocuments docBO;
        private readonly IConsecutiveConfig configBO;
        private readonly IDocumentType docTypeBO;

        public DocsController(DomainContext context, ILogger<DocsController> log)
        {
            logger = log;
            docBO = new DocumentBO(context);
            docTypeBO = new DocumentTypeBO(context);
            configBO = new ConsecutiveConfigBO(context);
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult CreateDoc([FromBody] DocumentsAM data)
        {
            try
            {
                ConsecutiveConfigAM consecutive = null;

                if (data.IdDocType == 1)
                    consecutive = configBO.GetFirst(j => j.Prefix == "CI");
                else if (data.IdDocType == 2)
                    consecutive = configBO.GetFirst(j => j.Prefix == "CE");

                string number = (++consecutive.Consecutive).ToString();
                number = number.PadLeft((10 - number.Length), '0');

                data.Consecutive = consecutive.Prefix + number;

                docBO.Create(data);
                configBO.Update(consecutive);

                return StatusCode(StatusCodes.Status201Created, new JsonResponse { Status = StatusCodes.Status201Created, Title = SUCCESFULLY, TraceId = Guid.NewGuid().ToString() });
            }
            catch (Exception e)
            {
                logger.LogInformation("Error: {mess}", e);
                return StatusCode(StatusCodes.Status500InternalServerError, new JsonResponse
                {
                    Status = StatusCodes.Status500InternalServerError,
                    Title = INTERNAL_ERROR,
                    Errors = new string[] { e.Message },
                    TraceId = Guid.NewGuid().ToString()
                });
            }
        }

        [HttpGet]
        [Route("[action]/{id}")]
        public List<DocumentsAM> GetDocs(string id)
        {
            try
            {
                return docBO.Get(j => j.IdUser == id);
            }
            catch (Exception e)
            {
                logger.LogInformation(e.Message);
                return null;
            }
        }

        [HttpGet]
        [Route("[action]")]
        public List<DocumentTypeAM> GetDocType()
        {
            try
            {
                return docTypeBO.Get();
            }
            catch (Exception e)
            {
                logger.LogInformation(e.Message);
                return null;
            }
        }
    }
}
