using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.DB;
using OnlineShop.DB.Models;
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
            var users = _userManager.Users;
            return View(users);
        }

        private User GetUserFromDB(string userId)
        {
            return _userManager.Users.FirstOrDefault(x => x.Id == userId);
        }

        public IActionResult Get(string userId)
        {
            var necessaryUser = _userManager.Users.FirstOrDefault(x => x.Id == userId);
            return View(necessaryUser);
        }

        //public IActionResult ChangePassword(int userId)
        //{
        //    var necessaryUser = _userManager.AllUsers().FirstOrDefault(x => x.Id == userId);
        //    var newPassword = new NewPassword
        //    {
        //        UserId = userId
        //    };
        //    return View(newPassword);
        //}

        //[HttpPost]
        //public IActionResult ChangePassword(NewPassword newPassword)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _userManager.NewPassword(newPassword);
        //        return RedirectToAction("GetUser", "User", new { userId = newPassword.UserId });
        //    }
        //    else
        //    {
        //        return View("Users");
        //    }
        //}

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
