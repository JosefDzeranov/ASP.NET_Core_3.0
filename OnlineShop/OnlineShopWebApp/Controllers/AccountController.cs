using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(Account account)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Index", "Home");
            }
            return View(account);
        }

        public IActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Registration(Registration register)
        {
            if(register.UserName == register.Password)
            {
                ModelState.AddModelError(string.Empty, "Имя и пароль не должны совпадать");
            }

            if (ModelState.IsValid)
            {
                return RedirectToAction("Index", "Home");
            }
            return View(register);
        }
    }
}