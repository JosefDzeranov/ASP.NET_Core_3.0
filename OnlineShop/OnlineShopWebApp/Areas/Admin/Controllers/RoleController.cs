using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Services;
using OnlineShopWebApp.Models;
using OnlineShopWebApp.Areas.Admin.Models;

namespace OnlineShopWebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class RoleController : Controller
    {
        private readonly IRolesRepository rolesRepository;

        public RoleController(IRolesRepository rolesRepository)
        {
            this.rolesRepository = rolesRepository;
        }
        public IActionResult Index()
        {
            var roles = rolesRepository.GetAll();
            return View(roles);
        }

        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]

        public IActionResult Add(Role role)
        {
            if (rolesRepository.TryGetByName(role.Name) != null)
            {
                ModelState.AddModelError("", "Такая роль уже существует");
            }
            if (ModelState.IsValid)
            {
                rolesRepository.Add(role);
                return RedirectToAction(nameof(Index));
            }
            return View(role);
        }

        public IActionResult Remove(string roleName)
        {
            rolesRepository.Remove(roleName);
            return RedirectToAction(nameof(Index));
        }
    }
}
