using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Areas.Admin.Models;
using OnlineShopWebApp.Models;
using OnlineShopWebApp.Services;

namespace OnlineShopWebApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUsersManager usersManager;

        public AccountController(IUsersManager usersManager)
        {
            this.usersManager = usersManager;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(Login login)
        {
            if (!ModelState.IsValid)
                return RedirectToAction(nameof(Login));
            
            var userAccount = usersManager.TryGetByName(login.InputEmail1);
            if (userAccount == null)
            {
                ModelState.AddModelError("", "Такого пользователя не существует");
                return RedirectToAction(nameof(Login));
            }
            
            if (userAccount.InputPassword != login.InputPassword)
            {
                ModelState.AddModelError("", "Неправильный логин или пароль");
                return RedirectToAction(nameof(Login));
            }

            return RedirectToAction(nameof(HomeController.Index), nameof(HomeController));
        }

        public IActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Registration(Registration registration)
        {
            if (registration.InputName == registration.InputPassword)
            {
                ModelState.AddModelError("", "Логин и пароль не должны совпадать!");
            }


            if (ModelState.IsValid)
            {
                usersManager.Add(new UserAccount
                {
                    Name = registration.InputName,
                    InputLastName = registration.InputLastName,
                    InputEmail1 = registration.InputEmail1,
                    InputPassword = registration.InputPassword,
                    InputConfirmPassword = registration.InputConfirmPassword,

                });
                return RedirectToAction(nameof(HomeController.Index), "Home");
            }
            return RedirectToAction(nameof(Registration));
        }
    }
}
