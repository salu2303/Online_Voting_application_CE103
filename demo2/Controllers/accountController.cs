using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using demo2.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace demo2.Controllers
{
    public class accountController : Controller
    {
        private readonly RoleManager<IdentityRole> rolemanager;

        public accountController(RoleManager<IdentityRole> rolemanager)
        {
            this.rolemanager = rolemanager;
        }
        public IActionResult Index()
        {
            return View();
        }
        
        [HttpGet]
        public IActionResult CreateRole()
        {
            return View(new IdentityRole());
        }
        [HttpPost]
        public async Task<IActionResult> CreateRole(IdentityRole role)
        {
            await rolemanager.CreateAsync(role);
            return RedirectToAction("CreateRole");
        }
    }
}
