using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.db;
using OnlineShop.db.Models;
using OnlineShopWebApp.Helpers;
using OnlineShopWebApp.Models;
using System;
using OnlineShopWebApp.Services;

namespace OnlineShopWebApp.Controllers
{
    public class RegistrationController : Controller
    {
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;
        private readonly ImagesProvider imagesProvider;
        private readonly IOrdersRepository ordersRepository;

        public RegistrationController(UserManager<User> userManager, SignInManager<User> signInManager, ImagesProvider imagesProvider, IOrdersRepository ordersRepository)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.imagesProvider = imagesProvider;
            this.ordersRepository = ordersRepository;
        }

        [HttpPost]
        public IActionResult Index(RegistrationViewModel registrationViewModel)
        {
            if (registrationViewModel.UserName == registrationViewModel.Login)
            {
                ModelState.AddModelError("", "Имя и логин не должны совпадать");
            }
            return View("Registration", registrationViewModel);
        }

        public IActionResult Register(string returnUrl)
        {
            return View(new RegistrationViewModel() { ReturnUrl = returnUrl });
        }

        [HttpPost]
        public IActionResult Register(RegistrationViewModel registrationViewModel)
        {
            if (ModelState.IsValid)
            {
                User user = new User
                {
                    UserName = registrationViewModel.UserName,
                    Email = registrationViewModel.Login,
                    PhoneNumber = registrationViewModel.Phone,
                    AvatarPath = registrationViewModel.ImagePath

                };
                var result = userManager.CreateAsync(user, registrationViewModel.Password).Result;
                if (result.Succeeded)
                {
                    signInManager.SignInAsync(user, false).Wait();
                    TryAssignUserRole(user);
                    return Redirect(registrationViewModel.ReturnUrl ?? "/Home");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }
            return View(registrationViewModel);
        }

        private void TryAssignUserRole(User user)
        {
            try
            {
                userManager.AddToRoleAsync(user, Const.UserRoleName).Wait();
            }
            catch (Exception)

            {
                throw;
            }
        }
    }
}
