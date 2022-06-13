using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.DB;
using OnlineShop.DB.Models;

namespace OnlineShopWebApp.Areas.Admin.Controllers
{
    //[Area(Const.AdminRoleName)]
    //[Authorize(Roles = Const.AdminRoleName)]
    //public class RoleController : Controller
    //{
    //    private readonly UserManager<User> _userManager;

    //    public RoleController(UserManager<User> userManager)
    //    {
    //        _userManager = userManager;
    //    }

    //    public IActionResult Index()
    //    {
    //        var roles = _userManager.GetAll();
    //        return View(roles);
    //    }

    //    public IActionResult AddRole()
    //    {
    //        return View();
    //    }

    //    [HttpPost]
    //    public IActionResult AddRole(Role role)
    //    {
    //        if (roleRepository.TryGetByName(role.Name) != null)
    //        {
    //            ModelState.AddModelError("", "Роль с таким именем уже существует");
    //        }
    //        if (ModelState.IsValid)
    //        {
    //            roleRepository.Add(role);
    //            return RedirectToAction("Index", "Role");
    //        }

    //        return View(role);
    //    }

    //    public IActionResult DeleteRole(string name)
    //    {
    //        roleRepository.Remove(name);

    //        return RedirectToAction("Index", "Role");
    //    }
    //}
}
