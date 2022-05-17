using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Interfase;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class RolesController : Controller
    {
        private readonly IRolesManeger rolesManeger;
        public RolesController(IRolesManeger rolesManeger)
        {
            this.rolesManeger = rolesManeger;
        }

        public IActionResult Index()
        {
            var roles = rolesManeger.GetAll();
            return View(roles);
        }
        public IActionResult Remove(string roleName)
        {
            rolesManeger.Remove(roleName);
            return RedirectToAction("Index");
        }

        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(Role role)
        {
            if (rolesManeger.TryGetByName(role.Name) != null)
            {
                ModelState.AddModelError("", "Такая роль уже существует");
            }
            if (ModelState.IsValid)
            {
                rolesManeger.Add(role);
                return RedirectToAction("Index");
            }
            return View(role);
        }
    }
}
