﻿using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Interfase;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class RolesController : Controller
    {
        private readonly IRolesStorage rolesStorage;
        public RolesController(IRolesStorage rolesStorage)
        {
            this.rolesStorage = rolesStorage;
        }

        public IActionResult Index()
        {
            var roles = rolesStorage.GetAll();
            return View(roles);
        }
        public IActionResult Remove(string roleName)
        {
            rolesStorage.Remove(roleName);
            return RedirectToAction("Index");
        }

        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(Role role)
        {
            if (rolesStorage.TryGetByName(role.Name) != null)
            {
                ModelState.AddModelError("", "Такая роль уже существует");
            }
            if (ModelState.IsValid)
            {
                rolesStorage.Add(role);
                return RedirectToAction("Index");
            }
            return View(role);
        }
    }
}
