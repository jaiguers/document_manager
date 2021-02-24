using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DocumentManager.CrossCutting.ApplicationModel;
using DocumentManager.Areas.Identity.Models;
using DocumentManager.Areas.Register.Models;
using Domain.Business.BO;
using Domain.Business.Interface;
using Domain.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;

namespace DocumentManager.Areas.Register.Controllers
{
    [Area("Register")]
    public class RegistersController : Controller
    {
        private readonly ILogger<RegistersController> logger;
        private readonly SignInManager<Users> singInManager;
        private readonly RoleManager<Role> roleManager;
        private readonly UserManager<Users> userManager;
        private readonly IIdentificationType IdTypeBO;
        private readonly IDepartment departmentBO;
        private readonly IPerson personBO;

        public RegistersController(DomainContext context, ILogger<RegistersController> log, UserManager<Users> userManag, SignInManager<Users> signInManag, RoleManager<Role> roleManag)
        {
            IdTypeBO = new IdentificationTypeBO(context);
            departmentBO = new DepartmentBO(context);
            personBO = new PersonBO(context);
            singInManager = signInManag;
            roleManager = roleManag;
            userManager = userManag;
            logger = log;
        }

        public IActionResult Index()
        {
            RegisterVM model = new RegisterVM();
            LoadInfo();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Index(RegisterVM model)
        {
            LoadInfo();

            try
            {
                if (ModelState.IsValid)
                {
                    model.Person.IdState = 1;
                    model.Person.RegistrationDate = DateTime.Now;

                    var personId = personBO.Create(model.Person);

                    if (personId > 0)
                    {
                        Users user = new Users
                        {
                            Email = model.Email,
                            UserName = model.Email,
                            IdPerson = personId,
                            IdState = 1,
                            IsExternal = true,
                            PasswordChangeDate = DateTime.Now.AddDays(300)
                        };

                        var resultCreated = await userManager.CreateAsync(user);
                        var passwordResult = await userManager.AddPasswordAsync(user, model.Password);
                        var asignRol = await userManager.AddToRoleAsync(user, "Proveedor");
                        // string confirmToken = await userManager.GenerateEmailConfirmationTokenAsync(user);
                        // string tokenEncode = System.Web.HttpUtility.UrlEncode(confirmToken);

                        return RedirectToAction("Login", "Account", new { area = "Identity" });
                    }
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message + " - /Register/Index");
            }


            return View(model);
        }

        [HttpGet]
        public IActionResult Internal()
        {
            InternalVM model = new InternalVM();
            LoadInfo();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Internal(InternalVM model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    model.Person.IdState = 1;
                    model.Person.RegistrationDate = DateTime.Now;

                    var personId = personBO.Create(model.Person);

                    if (personId > 0)
                    {
                        Users user = new Users
                        {
                            Email = model.Email,
                            UserName = model.Email,
                            IdPerson = personId,
                            IdState = 1,
                            IsExternal = false,
                            PasswordChangeDate = DateTime.Now.AddDays(300)
                        };

                        var resultCreated = await userManager.CreateAsync(user);
                        var passwordResult = await userManager.AddPasswordAsync(user, model.Password);
                        var asignRol = await userManager.AddToRoleAsync(user, "Supervisor");
                        // string confirmToken = await userManager.GenerateEmailConfirmationTokenAsync(user);
                        // string tokenEncode = System.Web.HttpUtility.UrlEncode(confirmToken);

                        return RedirectToAction("InternalLogin", "Account", new { area = "Identity" });
                    }
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message + " - /Register/Internal");
            }

            return View(model);

        }

        private void LoadInfo()
        {
            try
            {
                var depart = departmentBO.Get();

                ViewBag.ListIdType = new SelectList(IdTypeBO.Get(), "Id", "Name");
                ViewBag.ListDepartment = new SelectList(depart, "Id", "Name");
                ViewBag.ListCities = new SelectList(new List<CityAM>(), "Id", "Name");
                ViewBag.ListDep = new SelectList(depart, "Id", "Name");
                ViewBag.ListCity = new SelectList(new List<CityAM>(), "Id", "Name");
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message + " - Register/Register/LoadInfo");
            }


        }
    }
}
