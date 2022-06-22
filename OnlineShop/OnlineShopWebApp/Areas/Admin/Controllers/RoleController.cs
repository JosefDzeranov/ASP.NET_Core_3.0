using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using OnlineShopWebApp.Areas.Admin.Models;
using OnlineShopWebApp.Services;

namespace OnlineShopWebApp.Areas.Admin.Controllers
{
    [Area(Constants.AdminRoleName)]
    [Authorize(Roles = Constants.AdminRoleName)]
    public class RoleController : Controller
    {
        private readonly IRoleStorage roleStorage;

        public RoleController(IRoleStorage roleStorage)
        {
            this.roleStorage = roleStorage;
        }

        public IActionResult Index()
        {
            var roles = roleStorage.GetAll();
            return View(roles);
        }

        public IActionResult AddRole()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddRole(Role role)
        {
            if (roleStorage.TryGet(role.Name) != null)
            {
                ModelState.AddModelError("", "Роль с таким именем уже существует");
            }
            if (ModelState.IsValid)
            {
                roleStorage.AddRole(role);
                return RedirectToAction("Index", "Role");
            }

            return View(role);
        }

        public IActionResult DeleteRole(string name)
        {
            roleStorage.DeleteRole(name);

            return RedirectToAction("Index", "Role");
        }
    }
}