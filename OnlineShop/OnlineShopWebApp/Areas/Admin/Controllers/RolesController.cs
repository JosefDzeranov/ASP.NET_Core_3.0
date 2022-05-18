using System;
using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Interfase;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class RolesController : Controller
    {
        private readonly IRoleManager roleManager;
        public RolesController(IRoleManager roleManager)
        {
            this.roleManager = roleManager;
        }

        public IActionResult Index()
        {
            var roles = roleManager.GetAll();
            return View(roles);
        }
        public IActionResult Remove(Guid roleId)
        {
            roleManager.Remove(roleId);
            return RedirectToAction("Index");
        }

        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(Role role)
        {
            if (roleManager.Find(role.Id) != null)
            {
                ModelState.AddModelError("", "Такая роль уже существует");
            }
            if (ModelState.IsValid)
            {
                roleManager.Add(role);
                return RedirectToAction("Index");
            }
            return View(role);
        }
    }
}
