using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Models;


namespace OnlineShopWebApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUsersManager usersManager;

        public AccountController(IUsersManager usersManager)
        {
            this.usersManager = usersManager;
        }

        public IActionResult Login ()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(UserCredentials userCredentials)
        {
           if(!ModelState.IsValid)
             return RedirectToAction(nameof(Login));

           var userAccount= usersManager.TryGetByName(userCredentials.Login);
            if (userAccount==null)
            {
                ModelState.AddModelError("", "Такого пользователя не существует");
                return View(userCredentials); 
            }

            if (userAccount.Password!=userCredentials.Password)
            {
                ModelState.AddModelError("", "Неправильный пароль");
                return View(userCredentials);
            }

            return RedirectToAction(nameof(HomeController.Index),"Home");
  
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
                    Phone=registration.Phone,
                });

                return RedirectToAction(nameof(HomeController.Index), "Home");
            }

            return RedirectToAction(nameof(Register));
        }
    }
}
