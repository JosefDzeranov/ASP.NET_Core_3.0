using Microsoft.AspNetCore.Mvc;
using OnlineShop.DB;
using OnlineShopWebApp.Areas.Admin.Models;
using OnlineShopWebApp.Helpers;
using OnlineShopWebApp.Models;
using System.Linq;

namespace OnlineShopWebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
    {

        private readonly IUserBase _userBase;

        public UserController(IUserBase userBase)
        {
            _userBase = userBase;
        }

        public IActionResult Users()
        {
            var users = _userBase.AllUsers();
            return View(users);
        }

        public IActionResult Get(int userId)
        {
            var necessaryUser = _userBase.AllUsers().FirstOrDefault(x => x.Id == userId);
            return View(necessaryUser);
        }

        //public IActionResult ChangePassword(int userId)
        //{
        //    var necessaryUser = _userBase.AllUsers().FirstOrDefault(x => x.Id == userId);
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
        //        _userBase.NewPassword(newPassword);
        //        return RedirectToAction("GetUser", "User", new { userId = newPassword.UserId });
        //    }
        //    else
        //    {
        //        return View("Users");
        //    }
        //}

        public IActionResult Edit(int userId)
        {
            var necessaryUser = _userBase.AllUsers().FirstOrDefault(x => x.Id == userId);
            return View(necessaryUser);
        }

        [HttpPost]
        public IActionResult Edit(UserViewModel user)
        {
            if (ModelState.IsValid)
            {
                _userBase.Edit(user.ToUser());
                return RedirectToAction("GetUser", "User", new { userId = user.Id });
            }
            else
            {
                return View("Users");
            }
        }

        public IActionResult Delete(int userId)
        {
            _userBase.Delete(userId);
            return RedirectToAction("Users", "User");
        }
    }
}
