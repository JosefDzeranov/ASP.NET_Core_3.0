using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Areas.Admin.Models;
using Microsoft.AspNetCore.Authorization;
using OnlineShop.Db;
using Microsoft.AspNetCore.Identity;
using OnlineShop.Db.Models;
using System.Linq;
using System.Collections.Generic;
using OnlineShopWebApp.Helpers;

namespace OnlineShopWebApp.Areas.Admin.Controllers
{
    [Area(Constants.AdminRoleName)]
    [Authorize(Roles = Constants.AdminRoleName)]
    public class RoleController : Controller
    {
        RoleManager<IdentityRole> _roleManager;

        public RoleController(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }

        public IActionResult Index()
        {
            var roles = _roleManager.Roles.ToList();
            var roleViewModels = roles.ToRoleViewModels();
            return View(roleViewModels);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(string name)
        {
            if (ModelState.IsValid)
            {
                _roleManager.CreateAsync(new IdentityRole(name)).Wait();
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Edit(string id)
        {
            var role = _roleManager.FindByIdAsync(id).Result;
            var roleViewModel = role.ToRoleViewModel();
            return View(roleViewModel);
        }

        [HttpPost]
        public IActionResult Edit(RoleViewModel model)
        {
            if (ModelState.IsValid)
            {
                var role = _roleManager.FindByIdAsync(model.Id).Result;

                role.Name = model.Name;

                _roleManager.UpdateAsync(role).Wait();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public IActionResult Remove(string id)
        {
            var role = _roleManager.FindByIdAsync(id).Result;
            _roleManager.DeleteAsync(role).Wait();
            return RedirectToAction("Index");
        }
    }
}
