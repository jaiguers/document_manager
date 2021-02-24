using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AbbottProvider.Models;
using Domain.Business.BO;
using Domain.Business.Interface;
using Domain.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AbbottProvider.Controllers
{
    public class UtilsController : Controller
    {
        private readonly ICity cityBO;
        private readonly ILogger<UtilsController> logger;

        public UtilsController(DomainContext context, ILogger<UtilsController> log)
        {
            cityBO = new CityBO(context);
            logger = log;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetCities(long id)
        {
            var response = new ResponseModel { Message = "OK", Success = true };

            try
            {
                response.Result = cityBO.Get(j => j.IdDepartment == id);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                return Json(new ResponseModel { Message = ex.Message, Success = false });
            }

            return Json(response);
        }
    }
}
