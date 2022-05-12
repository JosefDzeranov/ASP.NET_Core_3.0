using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserStorage _userStorage;
        public UserController(IUserStorage userStorage)
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
            if(ModelState.IsValid)
            {
                _userStorage.AuthorizeUser(signin);
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        public IActionResult Signup()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Signup(SignUp signup)
        {
            if (ModelState.IsValid)
            {
                _userStorage.CreateUser(signup);
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
    }
}
