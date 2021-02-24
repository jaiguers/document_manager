using DocumentManager.Areas.Identity.Models;
using Domain.Business.BO;
using Domain.Business.Interface;
using Domain.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace DocumentManager.Controllers
{
    public class BaseController : Controller
    {
        private readonly UserManager<Users> userManager;
        private readonly RoleManager<Role> roleManager;
        private readonly IRolMenu rolMenuBO;

        public BaseController(UserManager<Users> userManag, RoleManager<Role> roleManag, DomainContext context)
        {
            userManager = userManag;
            roleManager = roleManag;
            rolMenuBO = new RolMenuBO(context);
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (HttpContext.Session.GetString("IdUsers") != null)
            {
                Users user = userManager.Users.Include(x => x.Person).FirstOrDefault(u => u.Id == HttpContext.Session.GetString("IdUsers"));

                var rol = userManager.GetRolesAsync(user);
                rol.Wait();

                var rolUser = roleManager.Roles.FirstOrDefault(x => x.Name == rol.Result[0]);

                ViewBag.Menus = rolMenuBO.Get(j => j.IdRol == rolUser.Id);

                ViewBag.Name = user.Person.Name + " " + user.Person.Surname;
                ViewBag.Rol = rol.Result[0];

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
