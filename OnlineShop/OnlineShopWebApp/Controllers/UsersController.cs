using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUserStorage _userStorage;
        public UsersController(IUserStorage userStorage)
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
                if (_userStorage.Authorize(signin))
                {
                    return RedirectToAction("Index", "Home");
                }
                else 
                {
                    return View("Faled");
                }
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
                _userStorage.AddUser(signup);
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
    }
}
