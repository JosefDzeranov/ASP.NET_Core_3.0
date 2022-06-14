using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.DB;
using OnlineShop.DB.Models;
using OnlineShopWebApp.Areas.Admin.Models;
using OnlineShopWebApp.Helpers;
using OnlineShopWebApp.Models;
using System.Linq;

namespace OnlineShopWebApp.Areas.Admin.Controllers
{
    [Area(Const.AdminRoleName)]
    [Authorize(Roles = Const.AdminRoleName)]
    public class UserController : Controller
    {

        private readonly UserManager<User> _userManager;

        public UserController(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public IActionResult Users()
        {
            var users = _userManager.Users.Select(x=> x.ToUserViewModel()).ToList();
            return View(users);
        }

        private User GetUserFromDB(string userId)
        {
            return _userManager.Users.FirstOrDefault(x => x.Id == userId);
        }

        public IActionResult Get(string userId)
        {
            var necessaryUser = _userManager.Users.FirstOrDefault(x => x.Id == userId).ToUserViewModel();
            return View(necessaryUser);
        }

        [HttpGet]
        public IActionResult ChangePassword(string userId)
        {
            var necessaryUser = _userManager.Users.FirstOrDefault(x => x.Id == userId);
            var newPassword = new NewPassword
            {
                UserId = userId
            };
            return View(newPassword);
        }

        [HttpPost]
        public IActionResult ChangePassword(NewPassword newPassword)
        {
            if (ModelState.IsValid)
            {
                var user = GetUserFromDB(newPassword.UserId);
                var result = _userManager.RemovePasswordAsync(user).Result;
                if(result.Succeeded)
                {
                    _userManager.AddPasswordAsync(user, newPassword.Password).Wait();
                }
                return RedirectToAction("Get", "User", new { userId = newPassword.UserId });
            }
            else
            {
                return View("Users");
            }
        }

        public IActionResult Edit(string userId)
        {
            var necessaryUser = GetUserFromDB(userId);
            return View(necessaryUser);
        }

        [HttpPost]
        public IActionResult Edit(UserViewModel user)
        {
            if (ModelState.IsValid)
            {
                Edit(user.Id);
                return RedirectToAction("Get", "User", new { userId = user.Id });
            }
            else
            {
                return View("Users");
            }
        }

        public IActionResult Delete(string userId)
        {
            var result = _userManager.DeleteAsync(GetUserFromDB(userId)).Result;
            if(result.Succeeded)
            {
                return RedirectToAction("Users", "User");
            }
            else
            {
                return View();
            }
            
        }
    }
}
