using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Interface;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserStorage _userStorage;
        
        public AccountController(IUserStorage userStorage)
        {
            _userStorage = userStorage;
        }

        public IActionResult Signin()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Signin(SignIn signin)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Index", "Home");
            }
            return View(signin);
        }

        public IActionResult Signup()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Signup(SignUp signup)
        {
            if(signup.Email == signup.Password)
            {
                ModelState.AddModelError(string.Empty, "Логин и пароль не должны совпадать");
            }

            if (ModelState.IsValid)
            {
                _userStorage.Add(signup);
                return RedirectToAction("Index", "Home");
            }
            return View(signup);
        }
    }
}