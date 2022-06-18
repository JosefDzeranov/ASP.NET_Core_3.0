using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Models;
using OnlineShopWebApp.Services;

namespace OnlineShopWebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
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

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Role role)
        {
            if (roleStorage.TryGet(role.Name) != null)
            {
                ModelState.AddModelError("", "Роль с таким именем уже существует");
            }
            if (ModelState.IsValid)
            {
                roleStorage.Add(role);
                return RedirectToAction("Index", "Role");
            }

            return View(role);
        }

        public IActionResult Remove(string name)
        {
            roleStorage.Remove(name);

            return RedirectToAction("Index", "Role");
        }
    }
}