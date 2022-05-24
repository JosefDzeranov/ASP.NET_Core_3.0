using System;
using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Filters;
using OnlineShopWebApp.Interfase;
using OnlineShopWebApp.Models.Users;

namespace OnlineShopWebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    [ServiceFilter(typeof(CheckingForAuthorization))]
    public class UsersController : Controller
    {
        private readonly IUserManager userManager;

        public UsersController(IUserManager userManager)
        {
             this.userManager = userManager;
        }
        public IActionResult Index()
        {
            var users = userManager.GetAll();
            return View(users);
        }

        public IActionResult Details(string login)
        {
            var user = userManager.FindByLogin(login);
            return View(user);
        }

        public IActionResult ChangePassword(string login)
        {
            ChangePassword changePassword = new ChangePassword()
            {
                Login = login
            };
            return View(changePassword);
        }
        [HttpPost]
        public IActionResult ChangePassword(ChangePassword changePassword)
        {
            if (changePassword.Login == changePassword.Password)
            {
                ModelState.AddModelError("", "Логин и пароль не должны совпадать!");
            }
            var user = userManager.FindByLogin(changePassword.Login);
            if (user.Password == changePassword.Password)
            {
                ModelState.AddModelError("", "Вы ввели существующий пароль!");
            }
            if (ModelState.IsValid)
            {
                userManager.ChangePassword(changePassword.Login, changePassword.Password);
                return RedirectToAction("Index", "Users");
            }
            return View(changePassword);
        }

        public IActionResult Edit()
        {
            if (changePassword.Login == changePassword.Password)
            {
                ModelState.AddModelError("", "Логин и пароль не должны совпадать!");
            }
            var user = userManager.FindByLogin(changePassword.Login);
            if (user.Password == changePassword.Password)
            {
                ModelState.AddModelError("", "Вы ввели существующий пароль!");
            }
            if (ModelState.IsValid)
            {
                userManager.ChangePassword(changePassword.Login, changePassword.Password);
                return RedirectToAction("Index", "Users");
            }
            return View(changePassword);
        }

        public IActionResult EditRights()
        {
            throw new NotImplementedException();
        }

        public IActionResult Delite()
        {
            throw new NotImplementedException();
        }
    }
}
