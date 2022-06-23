using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db.Models;
using OnlineShopWebApp.Helpers;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
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
                var result = signInManager.PasswordSignInAsync(signin.Email, signin.Password, signin.RememberMe, false).Result;
                if (result.Succeeded)
                {
                    if (signin.ReturnUrl != null)
                    {
                        return Redirect(signin.ReturnUrl ?? "/Home");
                    }
                    else
                    {
                        return RedirectToAction(nameof(HomeController.Index), "Home");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Неверный пароль!");
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

                var result = userManager.CreateAsync(user, signup.Password).Result;

                if (result.Succeeded)
                {
                    signInManager.SignInAsync(user, false).Wait();
                    return RedirectToAction(signup.ReturnUrl ?? "/Home"); 
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
                signInManager.SignOutAsync().Wait();

                return RedirectToAction("Index", "Home");
            }
        }
    }