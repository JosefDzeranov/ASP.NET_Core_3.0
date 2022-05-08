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
    }
}
