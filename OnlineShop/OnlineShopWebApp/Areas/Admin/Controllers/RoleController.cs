using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineShop.DB;
using OnlineShopWebApp.Services;
using System.Linq;
using System.Threading.Tasks;

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

        public async Task<IActionResult> Index()
        {
            var roles = await roleManager.Roles.ToListAsync();
            return View(roles);
        }

        public IActionResult AddRole()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddRoleAsync(IdentityRole role)
        {


            if (role != null)
            {
                if (await roleManager.FindByNameAsync(role.Name) != null)
                {
                    ModelState.AddModelError("", "Роль с таким именем уже существует");
                }
                else
                {
                    await roleManager.CreateAsync(new IdentityRole(role.Name));
                }

                return RedirectToAction("Index", "Role");
            }

            return View(role);
        }

        public async Task<IActionResult> DeleteRoleAsync(string name)
        {
            var role = await roleManager.FindByNameAsync(name);
            if (role != null)
            {
                await roleManager.DeleteAsync(role);

            }

            return RedirectToAction("Index", "Role");
        }
    }
}
