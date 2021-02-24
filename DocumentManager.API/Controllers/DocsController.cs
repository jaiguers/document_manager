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

        public DocsController(DomainContext context, ILogger<DocsController> log)
        {
            logger = log;
            docBO = new DocumentBO(context);
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult RegisterHours([FromBody] DocumentsAM data)
        {
            try
            {
                docBO.Create(data);

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
    }
}
