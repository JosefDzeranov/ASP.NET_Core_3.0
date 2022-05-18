using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Interfase;
using OnlineShopWebApp.Models.Users;
using System;

namespace OnlineShopWebApp.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUserManager userManager;
        public LoginController(IUserManager userManager)
        {
            this.userManager = userManager;
        }
        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Registration(User user)
        {
            if (userManager.FindByLogin(user.Login) != null)
            {
                ModelState.AddModelError("", "Такой аккаунт уже существует");
            }
            if (user.Password != user.PasswordConfirm)
            {
                ModelState.AddModelError("", "Проверочный пароль должен совпадать с паролем");
            }
            if (!ModelState.IsValid)
            {
                return Content("errorValid");
            }
            userManager.Add(user);
            userManager.AssignRole(user.Login, Guid.Parse("674b2f41-3173-4a0c-8f7e-4043876b8ee3")); //Покупатель
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Enter(User userInput)
        {
            var user = userManager.FindByLogin(userInput.Login);
            if (userManager.FindByLogin(userInput.Login) == null)
            {
                ModelState.AddModelError("", "Такого аккаунта не существует");
            }
            if (userInput.Password != user.Password)
            {
                ModelState.AddModelError("", "Пароль введён неверно");
            }
            if (!ModelState.IsValid)
            {
                return Content("errorValid");
            }
            userManager.Authorized(userInput);
            return RedirectToAction("Index", "User");
        }


        public IActionResult NewUser()
        {
            return View();
        }

        public IActionResult TabooAccess()
        {
            return View();
        }
    }
}
