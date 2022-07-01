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
        private readonly ICompareStorage _compareStorage;
        private readonly IFavoritesStorage _favoritesStorage;
        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager, IBasketStorage basketStorage, ICompareStorage compareStorage, IFavoritesStorage favoritesStorage)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _basketStorage = basketStorage;
            _compareStorage = compareStorage;
            _favoritesStorage = favoritesStorage;
        }

        public IActionResult Index()
        {
            return View();
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
                    SetUserId(model.Email); // Setting authorized user id to Basket, Compare or Favorites if nesessary. 

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

                    SetUserId(model.Email); // Setting authorized user id to Basket, Compare or Favorites if nesessary.

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

        private void SetUserId(string name)
        {
            var tempUserId = HttpContext.Request.Cookies["tempUserId"];

            var basket = _basketStorage.TryGetByUserId(tempUserId);
            if (basket != null)
            {
                var currentUserId = _userManager.FindByNameAsync(name).Result.Id;
                _basketStorage.ChangeUserId(tempUserId, currentUserId);
            }

            var compareProducts = _compareStorage.GetAllByUserId(tempUserId);
            if (compareProducts != null)
            {
                var currentUserId = _userManager.FindByNameAsync(name).Result.Id;
                _compareStorage.ChangeUserId(tempUserId, currentUserId);
            }

            var favorites = _favoritesStorage.GetAllByUserId(tempUserId);
            if (favorites != null)
            {
                var currentUserId = _userManager.FindByNameAsync(name).Result.Id;
                _favoritesStorage.ChangeUserId(tempUserId, currentUserId);
            }
        }
    }
}
