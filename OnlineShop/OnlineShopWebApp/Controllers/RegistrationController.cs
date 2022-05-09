using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Areas.Admin.Models;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Controllers
{
    public class RegistrationController : Controller
    {
        private readonly IUsersManager usersManager;

        public RegistrationController(IUsersManager usersManager)
        {
            this.usersManager = usersManager;
        }

        public IActionResult Index() //хочу удалить
        {
            return View();
        }


        [HttpPost]
        public IActionResult Index(Registration registration)
        {
            if (registration.UserName == registration.Login)
            {
                ModelState.AddModelError("", "Имя и логин не должны совпадать");
            }

            return View("Registration");
        }


        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]

        public IActionResult Register(Registration registration)
        {
            if (registration.UserName == registration.Password)
            {
                ModelState.AddModelError("", "Логин и пароль не должны совпадать");
            }

            if (ModelState.IsValid)
            {
                usersManager.Add(new UserAccount
                {
                    Name = registration.UserName,
                    Password = registration.Password,
                });

                return RedirectToAction(nameof(HomeController.Index), "Home");
            }

            return RedirectToAction(nameof(Register));
        }
    }
}
