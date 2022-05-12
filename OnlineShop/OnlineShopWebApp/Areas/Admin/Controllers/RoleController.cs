using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Areas.Admin.Models;

namespace OnlineShopWebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class RoleController : Controller
    {
        private readonly IRoleStorage _roleStorage;
        public RoleController(IRoleStorage roleStorage)
        {
            _roleStorage = roleStorage;
        }

        public IActionResult Index()
        {
            var roles = _roleStorage.GetAll();
            return View(roles);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(string name)
        {
            if(ModelState.IsValid)
            {
                _roleStorage.Add(name);
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Edit(string name)
        {
            var role = _roleStorage.TryGetRoleByName(name);
            return View(role);
        }

        [HttpPost]
        public IActionResult Save(string oldName, Role role)
        {
            if(ModelState.IsValid)
            {
                _roleStorage.Edit(oldName, role);
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Remove(string name)
        {
            _roleStorage.Remove(name);
            return RedirectToAction("Index");
        }
    }
}
