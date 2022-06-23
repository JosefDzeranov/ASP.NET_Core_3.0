using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using OnlineShopWebApp.Areas.Admin.Models;
using OnlineShopWebApp.Helpers;
using System.Linq;

namespace OnlineShopWebApp.Areas.Admin.Controllers
{
    [Area(Constants.AdminRoleName)]
    [Authorize(Roles = Constants.AdminRoleName)]
    public class RoleController : Controller
    {
        RoleManager<IdentityRole> roleManager;

        public RoleController(RoleManager<IdentityRole> roleManager)
        {
            this.roleManager = roleManager;
        }

        public IActionResult Index()
        {
            var roles = roleManager.Roles.ToList();
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
            var result = roleManager.CreateAsync(new IdentityRole(name)).Result;
            if (result.Succeeded)
            {
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            return View();
        }

        public IActionResult Delete(string id)
        {
            var role = roleManager.FindByIdAsync(id).Result;
            roleManager.DeleteAsync(role).Wait();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Edit(RoleViewModel model)
        {
            if (ModelState.IsValid)
            {
                var role = roleManager.FindByIdAsync(model.Id).Result;

                role.Name = model.Name;

                roleManager.UpdateAsync(role).Wait();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public IActionResult Edit(string id)
        {
            var role = roleManager.FindByIdAsync(id).Result;
            var roleViewModel = role.ToRoleViewModel();
            return View(roleViewModel);
        }
    }
}