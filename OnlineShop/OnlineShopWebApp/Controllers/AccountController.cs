using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using OnlineShop.Db.Models;
using OnlineShopWebApp.Models;
using OnlineShopWebApp.Helpers;

namespace OnlineShopWebApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public IActionResult Signin(string returnUrl)
        {
            return View(new SigninViewModel() { ReturnUrl = returnUrl });
        }

        [HttpPost]
        public IActionResult Signin(SigninViewModel signin)
        {
            if (ModelState.IsValid)
            {
                var result = _signInManager.PasswordSignInAsync(signin.Email, signin.Password, signin.RememberMe, false).Result;
                if (result.Succeeded)
                {
                    return Redirect(signin.ReturnUrl ?? "/Home");
                }
                else
                {
                    return View("Failed");
                }
            }
            return View(signin);
        }

        public IActionResult Signup(string returnUrl)
        {
            return View(new SignupViewModel() { ReturnUrl = returnUrl });
        }

        [HttpPost]
        public IActionResult Signup(SignupViewModel signup)
        {
            if (ModelState.IsValid)
            {
                var user = signup.ToUser();
                var result = _userManager.CreateAsync(user, signup.Password).Result;

                if (result.Succeeded)
                {
                    _signInManager.SignInAsync(user, false).Wait();
                    return Redirect(signup.ReturnUrl ?? "/Home");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
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
