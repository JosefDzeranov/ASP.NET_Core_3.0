using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using OnlineShop.Db.Models;
using OnlineShopWebApp.Models;
using OnlineShopWebApp.Helpers;
using OnlineShop.Db;

namespace OnlineShopWebApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IBasketStorage _basketStorage;
        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager, IBasketStorage basketStorage)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _basketStorage = basketStorage;
        }

        public IActionResult Signin(string returnUrl)
        {
            return View(new SigninViewModel() { ReturnUrl = returnUrl });
        }

        [HttpPost]
        public IActionResult Signin(SigninViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false).Result;
                if (result.Succeeded)
                {
                    SetUserIdToBasket(model.Email);

                    return Redirect(model.ReturnUrl ?? "/Home");
                }
                else
                {
                    return View("Failed");
                }
            }
            return View(model);
        }

        public IActionResult Signup(string returnUrl)
        {
            return View(new SignupViewModel() { ReturnUrl = returnUrl });
        }

        [HttpPost]
        public IActionResult Signup(SignupViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = model.ToUser();
                var result = _userManager.CreateAsync(user, model.Password).Result;

                if (result.Succeeded)
                {
                    _signInManager.SignInAsync(user, false).Wait();

                    SetUserIdToBasket(model.Email);

                    return Redirect(model.ReturnUrl ?? "/Home");
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

        private void SetUserIdToBasket(string name)
        {
            var tempUserId = HttpContext.Request.Cookies["tempUserId"];
            var basket = _basketStorage.TryGetByUserId(tempUserId);
            if (basket != null)
            {
                var currentUserId = _userManager.FindByNameAsync(name).Result.Id;
                _basketStorage.ChangeUserId(tempUserId, currentUserId);
            }
        }
    }
}
