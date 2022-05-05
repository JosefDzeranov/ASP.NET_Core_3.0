using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Models;
using OnlineShopWebApp.Services;

namespace OnlineShopWebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class RoleController : Controller
    {
        private readonly IRoleRepository roleRepository;

        public RoleController(IRoleRepository roleRepository)
        {
            this.roleRepository = roleRepository;
        }

        public IActionResult Index()
        {
            var roles = roleRepository.GetAll();
            return View(roles);
        }

        public IActionResult AddRole()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddRole(Role role)
        {
            if (roleRepository.TryGetByName(role.Name) != null)
            {
                ModelState.AddModelError("", "Роль с таким именем уже существует");
            }
            if (ModelState.IsValid)
            {
                roleRepository.Add(role);
                return RedirectToAction("Index", "Role");
            }

            return View(role);
        }

        public IActionResult DeleteRole(string name)
        {
            roleRepository.Remove(name);

            return RedirectToAction("Index", "Role");
        }
    }
}
