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
                _userStorage.AuthorizeUser(signin);
            }
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Signup()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Signup(SignUp signup)
        {
            if(signup.FirstName == signup.Password)
            {
                ModelState.AddModelError("", "FirstName and Password fields cannot be the same.");
            }

            if (signup.LastName == signup.Password)
            {
                ModelState.AddModelError("", "LastName and Password fields cannot be the same.");
            }

            if (ModelState.IsValid)
            {
                _userStorage.CreateUser(signup);
            }
            return RedirectToAction("Index", "Home");
        }
    }
}
