using System;
using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Filters;
using OnlineShopWebApp.Interfase;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    [ServiceFilter(typeof(CheckingForAuthorization))]
    public class RolesController : Controller
    {
        private readonly IRoleManager _roleManager;
        public RolesController(IRoleManager roleManager)
        {
            _roleManager = roleManager;
        }

        public IActionResult Index()
        {
            var roles = _roleManager.GetAll();
            return View(roles);
        }
        public IActionResult Remove(Guid roleId)
        {
            _roleManager.Remove(roleId);
            return RedirectToAction("Index");
        }

        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(Role role)
        {
            if (_roleManager.Find(role.Id) != null)
            {
                ModelState.AddModelError("", "Такая роль уже существует");
            }
            if (ModelState.IsValid)
            {
                _roleManager.Add(role);
                return RedirectToAction("Index");
            }
            return View(role);
        }
    }
}
