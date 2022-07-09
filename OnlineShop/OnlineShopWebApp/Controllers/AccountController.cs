using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using OnlineShop.Db.Models;
using OnlineShopWebApp.Models;
using OnlineShopWebApp.Helpers;
using OnlineShop.Db;
using System;
using OnlineShopWebApp.Areas.Admin.Models;

namespace OnlineShopWebApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IBasketStorage _basketStorage;
        private readonly ICompareStorage _compareStorage;
        private readonly IFavoritesStorage _favoritesStorage;
        private readonly IOrderStorage _orderStorage;
        private readonly RoleManager<IdentityRole> _roleManager;
        public AccountController(UserManager<User> userManager, 
                                 SignInManager<User> signInManager, 
                                 IBasketStorage basketStorage, 
                                 ICompareStorage compareStorage, 
                                 IFavoritesStorage favoritesStorage,
                                 IOrderStorage orderStorage,
                                 RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _basketStorage = basketStorage;
            _compareStorage = compareStorage;
            _favoritesStorage = favoritesStorage;
            _orderStorage = orderStorage;
            _roleManager = roleManager;
        }


        [Authorize]
        public IActionResult Profile()
        {
            var userId = _userManager.GetUserId(User);
            var user = _userManager.FindByIdAsync(userId).Result;
            var userRoles = _userManager.GetRolesAsync(user).Result;
            var userViewModel = user.ToUserViewModel(userRoles);
            return View(userViewModel);
        }

        public IActionResult ChangePassword(Guid id)
        {
            var user = _userManager.FindByIdAsync(id.ToString()).Result;
            var data = new ChangePasswordViewModel()
            {
                Id = Guid.Parse(user.Id),
                FirstName = user.FirstName,
                LastName = user.LastName
            };
            return View(data);
        }

        [HttpPost]
        public IActionResult ChangePassword(ChangePasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = _userManager.FindByIdAsync(model.Id.ToString()).Result;
                _userManager.ChangePasswordAsync(user, model.CurrentPassword, model.NewPassword).Wait();
                return View("Success");
            }
            return View(model);
        }

        public IActionResult Edit(Guid id)
        {
            var user = _userManager.FindByIdAsync(id.ToString()).Result;
            var userViewModel = user.ToUserViewModel();
            return View(userViewModel);
        }

        [HttpPost]
        public IActionResult Edit(UserViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = _userManager.FindByIdAsync(model.Id.ToString()).Result;

                user.FirstName = model.FirstName;
                user.LastName = model.LastName;
                user.UserName = model.Email;
                user.Email = model.Email;
                user.PhoneNumber = model.Phone;

                _userManager.UpdateAsync(user).Wait();
                return RedirectToAction("Profile");
            }
            return View(model);
        }


        [Authorize]
        public IActionResult Orders()
        {
            var userId = _userManager.GetUserId(User);
            var userOrders = _orderStorage.TryGetAllByUserId(userId);
            var orderViewModels = userOrders.ToOrderViewModels();
            return View(orderViewModels);
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
