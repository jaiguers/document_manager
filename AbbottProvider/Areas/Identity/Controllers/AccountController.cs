using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DocumentManager.Areas.Identity.Models;
using DocumentManager.Areas.Identity.Models.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace DocumentManager.Areas.Identity.Controllers
{
    [Area("Identity")]
    public class AccountController : Controller
    {
        private readonly SignInManager<Users> singInManager;
        private readonly ILogger<AccountController> logger;
        private readonly UserManager<Users> userManager;
        private readonly RoleManager<Role> roleManager;

        public IConfiguration Configuration { get; }

        public AccountController(ILogger<AccountController> log, UserManager<Users> userManag, SignInManager<Users> signInManag, RoleManager<Role> roleManag, IConfiguration configuration)
        {
            logger = log;
            roleManager = roleManag;
            userManager = userManag;
            singInManager = signInManag;
            Configuration = configuration;
        }

        [HttpGet]
        public IActionResult Login()
        {
            logger.LogInformation("Info: {msg}", "Identity/Account/Login");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginVM model)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    Users user = await userManager.FindByEmailAsync(model.Email);
                    var result = await singInManager.PasswordSignInAsync(model.Email, model.Password, true, false);

                    if (user != null)
                    {
                        if (user.IsExternal)
                        {
                            if (user.IdState == 1)
                            {
                                if (result.Succeeded)
                                {
                                    HttpContext.Session.SetString("IdUsers", user.Id);
                                    return RedirectToAction("Index", "Home", new { area = "" });
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                logger.LogError("Error: {msg}", ex);
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult InternalLogin()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> InternalLogin(LoginVM model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Users user = await userManager.FindByEmailAsync(model.Email);
                    var result = await singInManager.PasswordSignInAsync(model.Email, model.Password, true, false);

                    if (user != null)
                    {
                        if (!user.IsExternal)
                        {
                            if (user.IdState == 1)
                            {
                                if (result.Succeeded)
                                {
                                    HttpContext.Session.SetString("IdUsers", user.Id);
                                    return RedirectToAction("Index", "Home", new { area = "" });
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                logger.LogError("Error: {msg}", ex);
            }

            return View(model);
        }

        public async Task<IActionResult> Logout()
        {
            await singInManager.SignOutAsync();
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            HttpContext.Session.Clear();

            foreach (var cookie in HttpContext.Request.Cookies.Keys)
                Response.Cookies.Delete(cookie);


            return RedirectToAction("Login", "Account", new { area = "Identity" });
        }

        public IActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordVM model)
        {
            var user = await userManager.FindByEmailAsync(model.Email);

            if (user != null)
            {
                List<string> roles = await userManager.GetRolesAsync(user) as List<string>;
                var rol = roleManager.Roles.FirstOrDefault(x => x.Name == roles[0]);

                if (rol.IsExternal)
                {
                    string resetToken = await userManager.GeneratePasswordResetTokenAsync(user);
                    string tokenEncode = System.Web.HttpUtility.UrlEncode(resetToken);

                    CreateModal("exito", "Terminado", "Se ha enviado correo electrónico para completar el proceso.", "Continuar", null, "Redirect('/')", null);
                    return View(model);

                }
                else
                {
                    CreateModal("error", "Error", "No es posible realizar la operación.", "Continuar", null, "Redirect('/')", null);
                    return View(model);
                }
            }
            else
            {
                CreateModal("error", "Error", "No se encontró usuario asociado al email", "Continuar", null, "Redirect('/')", null);
                return View(model);
            }
        }

        [HttpGet]
        public IActionResult RecoverPassword(string token, string u)
        {
            RecoverPasswordVM model = new RecoverPasswordVM
            {
                UserId = u,
                RecoverToken = token
            };

            ViewBag.Success = false;

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> RecoverPassword(RecoverPasswordVM model)
        {
            string decodeToken = System.Web.HttpUtility.UrlDecode(model.RecoverToken);

            Users user = await userManager.FindByIdAsync(model.UserId);
            var result = await userManager.ResetPasswordAsync(user, decodeToken, model.Password);
            var updateResult = await userManager.UpdateAsync(user);

            if (result.Succeeded && updateResult.Succeeded)
            {
                CreateModal("exito", "Terminado", "Contraseña actualizada satisfactoriamente.", "Continuar", null, "Redirect('/')", null);
                return View(model);
            }
            else
            {
                if (result.Errors.ToList()[0].Description == "Invalid token.")
                    CreateModal("error", "Error", "El token para recuperación del password se ha vencido o ha sido usado previamente.", "Continuar", null, "Redirect('/')", null);
                else
                    CreateModal("error", "Error", result.Errors.ToList()[0].Description, "Continuar", null, "Redirect('/')", null);

                return View(model);
            }
        }

        #region MODAL MESSAGE
        /// <summary>
        /// Generar modal desde el servidor
        /// </summary>
        /// <param name="type">Tipo de modal</param>
        /// <param name="title">Título del modal</param>
        /// <param name="message">Mensaje del modal</param>
        /// <param name="labelOk">Label para el botón OK</param>
        /// <param name="labelNo">Label para el botón cancelar</param>
        /// <param name="fOk">Función para el botón OK</param>
        /// <param name="fNo">Función para el botón cancelar</param>
        public void CreateModal(string type, string title, string message, string labelOk, string labelNo, string fOk, string fNo)
        {
            ViewBag.Modal = true;
            ViewBag.ModalType = type;
            ViewBag.ModalTitle = title;
            ViewBag.ModalMessage = message;
            ViewBag.ModalLabelOk = labelOk;
            ViewBag.ModalLabelNo = labelNo;
            ViewBag.ModalOk = fOk;
            ViewBag.ModalNo = fNo;
        }
        #endregion
    }
}
