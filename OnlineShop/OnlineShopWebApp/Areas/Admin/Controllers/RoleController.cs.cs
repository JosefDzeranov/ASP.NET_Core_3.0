using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.DB;
using System.Linq;

namespace OnlineShopWebApp.Areas.Admin.Controllers
{
    [Area(Const.AdminRoleName)]
    [Authorize(Roles = Const.AdminRoleName)]
    public class RoleController : Controller
    {
        private readonly RoleManager<IdentityRole> roleManager;

        public RoleController(RoleManager<IdentityRole> roleManager)
        {
            this.roleManager = roleManager;
        }

        public IActionResult Index()
        {
            var roles = roleManager.Roles.ToList();
            return View(roles);
        }

        public IActionResult AddRole()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddRole(IdentityRole role)
        {


            if (role != null)
            {
                if (roleManager.FindByNameAsync(role.Name).Result != null)
                {
                    ModelState.AddModelError("", "Роль с таким именем уже существует");
                }
                else
                {
                    roleManager.CreateAsync(new IdentityRole(role.Name)).Wait();
                }

                return RedirectToAction("Index", "Role");
            }

            return View(role);
        }

        public IActionResult DeleteRole(string name)
        {
            var role = roleManager.FindByNameAsync(name).Result;
            if (role != null)
            {
                roleManager.DeleteAsync(role).Wait();

            }

            return RedirectToAction("Index", "Role");
        }
    }
}