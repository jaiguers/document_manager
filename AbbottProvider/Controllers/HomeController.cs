using DocumentManager.Areas.Identity.Models;
using DocumentManager.Models;
using Domain.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace DocumentManager.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ILogger<HomeController> logger;

        public HomeController(ILogger<HomeController> log, UserManager<Users> userManag, RoleManager<Role> roleManag, DomainContext context)
            : base(userManag, roleManag, context)
        {
            logger = log;
        }

        public IActionResult Dashboard()
        {
            return View();
        }

        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("IdUsers") != null)
            {
                logger.LogInformation("Info: {msg}", "/Home/Index");
                return RedirectToAction("Dashboard", "Home", new { area = "" });
            }
            else
                return RedirectToAction("Login", "Account", new { area = "Identity" });

        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
