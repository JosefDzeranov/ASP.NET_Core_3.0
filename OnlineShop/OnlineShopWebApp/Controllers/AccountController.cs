using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUsersRepository usersRepository;

        public AccountController(IUsersRepository usersRepository)
        {
            this.usersRepository = usersRepository;
        }

        public IActionResult Authorization()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Authorization(EnterData enterData)
        {
            if (!ModelState.IsValid)
            {
                return View(nameof(Authorization));
            }
            var user = usersRepository.TryGetByLogin(enterData.Login);
            if (user == null)
            {
                ModelState.AddModelError("", "Такого пользователя не существует");
                return RedirectToAction(nameof(Authorization));
            }
            if (enterData.Password != user.Password)
            {
                ModelState.AddModelError("", "Неверный пароль");
                return RedirectToAction(nameof(Authorization));
            }
            return RedirectToAction(nameof(HomeController.Index), "Home");
        }

        public IActionResult Registration()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Registration(RegistrationData registrationData)
        {
            if (ModelState.IsValid)
            {
                usersRepository.Add(new UserAccount
                {
                    Login = registrationData.Login,
                    Password = registrationData.Password,
                    Name = registrationData.Name,
                    Age = registrationData.Age,
                    Email = registrationData.Email
                });
                return RedirectToAction(nameof(HomeController.Index), "Home");
            }
            else
            {
                return View(registrationData);
            }
        }
    }
}
