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
            return View(new SigninViewModel() { ReturnUrl = returnUrl});
        }

        [HttpPost]
        public IActionResult Signin(SigninViewModel signin)
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
        public IActionResult Signup(SignupViewModel signup)
        {
            if (ModelState.IsValid)
            {
                var user = new User
                {
                    UserName = signup.Email
                };

                var result = _userManager.CreateAsync(user, signup.Password).Result;

                if (result.Succeeded)
                {
                    _signInManager.SignInAsync(user, false).Wait();
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("Email", "The user with this email is already registered.");
                }
            }
            return View();
        }

        [Authorize]
        public IActionResult Signout()
        {
            _signInManager.SignOutAsync().Wait();
            return RedirectToAction("Index", "Home");
        }
    }
}
