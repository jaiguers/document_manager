using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abbott.CrossCutting.Enumerators;
using AbbottProvider.Areas.Identity.Models;
using AbbottProvider.Controllers;
using Domain.Context;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace AbbottProvider.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UsersController : BaseController
    {
        private readonly ILogger<UsersController> logger;
        private readonly UserManager<Users> userManager;
        private readonly RoleManager<Role> roleManager;

        public UsersController(DomainContext context, ILogger<UsersController> log, UserManager<Users> userManag, RoleManager<Role> roleManag) : base(userManag, roleManag, context)
        {
            logger = log;
            userManager = userManag;
            roleManager = roleManag;
        }


        [HttpGet]
        [Authorize(Roles = RolesEnum.ADMIN)]
        public IActionResult Index()
        {
            List<Users> userData = userManager.Users.Include(j => j.Person).Include(j => j.UsersRoles).ThenInclude(j => j.Role).Where(j => j.IdState == 1).ToList();
            ViewBag.usersData = userData;

            return View();
        }
    }
}
