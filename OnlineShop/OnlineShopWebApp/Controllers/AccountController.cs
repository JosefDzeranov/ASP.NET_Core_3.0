using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using OnlineShop.Db.Models;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserStorage _userStorage;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        public AccountController(IUserStorage userStorage, UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userStorage = userStorage;
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public IActionResult Signin(string returnUrl)
        {
            return View(new SignIn() { ReturnUrl = returnUrl});
        }

        [HttpPost]
        public IActionResult Signin(SignIn signin)
        {
            if(ModelState.IsValid)
            {
                var result = _signInManager.PasswordSignInAsync(signin.Email, signin.Password, signin.RememberMe, false).Result;
                if (result.Succeeded)
                {
                    return Redirect(signin.ReturnUrl);
                }
                else 
                {
                    return View("Failed");
                }
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
            if (ModelState.IsValid)
            {
                _userStorage.Add(signup);
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
    }
}
