using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Areas.Admin.Models;
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

        public IActionResult GetUser(int userId)
        {
            var necessaryUser = _userBase.AllUsers().FirstOrDefault(x => x.Id == userId);
            return View(necessaryUser);
        }

        public IActionResult ChangePassword(int userId)
        {
            var necessaryUser = _userBase.AllUsers().FirstOrDefault(x => x.Id == userId);
            var newPassword = new NewPassword();
            newPassword.UserId = userId;
            return View(newPassword);
        }

        [HttpPost]
        public IActionResult ChangePassword(NewPassword newPassword)
        {
            if (ModelState.IsValid)
            {
                _userBase.NewPassword(newPassword);
                return RedirectToAction("GetUser", "User", new { userId = newPassword.UserId });
            }
            else
            {
                return View("Users");
            }
        }

        public IActionResult Edit(int userId)
        {
            var necessaryUser = _userBase.AllUsers().FirstOrDefault(x => x.Id == userId);
            return View(necessaryUser);
        }

        [HttpPost]
        public IActionResult Edit(User user)
        {
            if (ModelState.IsValid)
            {
                _userBase.Edit(user);
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

        public IActionResult AddNewUser()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddNewUser(User user)
        {
            if (ModelState.IsValid)
            {
                _userBase.Add(user);
                return RedirectToAction("Users", "User");
            }
            else
            {
                return View("AddNewUser");
            }
        }
    }
}
