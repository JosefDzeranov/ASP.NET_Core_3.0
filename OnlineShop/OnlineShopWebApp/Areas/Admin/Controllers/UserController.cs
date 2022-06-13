using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using OnlineShopWebApp.Models;
using Microsoft.AspNetCore.Identity;
using OnlineShopWebApp.Helpers;
using OnlineShop.db.Models;
using System.Linq;
using System.Collections.Generic;
using OnlineShop.db;

namespace OnlineShopWebApp.Areas.Admin.Controllers
{
    [Area(Constants.AdminRoleName)]
    [Authorize(Roles = Constants.AdminRoleName)]

    public class UserController : Controller
    {
        private readonly UserManager<User> userManager;

        public UserController(UserManager<User> usersManager)
        {
            this.userManager = usersManager;
        }
        public IActionResult Index()
        {
            var users = userManager.Users.ToList();
            return View(users.Select(u => u.ToUserViewModel()).ToList());
        }
        public IActionResult Detail(string name)
        {
            var user = userManager.FindByNameAsync(name).Result;
            return View(user.ToUserViewModel());
        }
        public IActionResult ChangePassword(string id)
        {
            var changePassword = new ChangePassword()
            {
                UserName = id
            };
            return View(changePassword);
        }

        [HttpPost]
        public IActionResult ChangePassword(ChangePassword changePassword)
        {
            if (changePassword.UserName == changePassword.Password)
            {
                ModelState.AddModelError("", "Логин и пароль не должны совпадать");
            }

            if (ModelState.IsValid)
               
            {
                var user = userManager.FindByNameAsync(changePassword.UserName).Result;
                var newHashPassword = userManager.PasswordHasher.HashPassword(user, changePassword.Password);
                user.PasswordHash = newHashPassword;
                userManager.UpdateAsync(user).Wait();
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(ChangePassword));
        }
        public IActionResult Remove (string name)
        {
            var user = userManager.FindByNameAsync(name).Result;
            userManager.DeleteAsync(user).Wait();
            return RedirectToAction(nameof(Index));

        }

        [HttpGet]
        public IActionResult Edit(string name)
        {
            var user = userManager.FindByNameAsync(name).Result;
            return View(user.ToUserViewModel());
        }

        [HttpPost]
        public IActionResult Edit(UserViewModel userAccount)
        {
            if (ModelState.IsValid)
            {
                var user=userManager.FindByNameAsync(userAccount.Name).Result;

                user.UserName = userAccount.Name;
                user.PhoneNumber = userAccount.Phone;
                user.Email = userAccount.Email;

                userManager.UpdateAsync(user).Wait();
                return RedirectToAction("Index");
            }
            else
            {
                return View(userAccount);
            }
        }
   
    }
}
