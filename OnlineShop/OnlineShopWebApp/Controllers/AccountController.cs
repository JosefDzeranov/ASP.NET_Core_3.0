using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using OnlineShop.Db.Models;
using OnlineShopWebApp.Helpers;
using OnlineShopWebApp.Models;
using System;

namespace OnlineShopWebApp.Controllers
{
    public class AccountController : Controller
    {        
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;
        private readonly RoleManager<IdentityRole> rolesManager;
        private readonly ImagesProvider imagesProvider;

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager, RoleManager<IdentityRole> rolesManager, ImagesProvider imagesProvider)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.rolesManager = rolesManager;
            this.imagesProvider = imagesProvider;
        }


        public IActionResult Login(string returnUrl)
        {
            return View(new EnterData() { ReturnUrl = returnUrl });
        }

        [HttpPost]
        public IActionResult Login(EnterData enterData)
        {
            if (ModelState.IsValid)
            {
                var result = signInManager.PasswordSignInAsync(enterData.Login, enterData.Password, enterData.Remember, false).Result;
                if (result.Succeeded)
                {
                    return Redirect(enterData.ReturnUrl ?? "/Home");
                }
                else
                {
                    ModelState.AddModelError("", "Неверный логин или пароль");
                }
            }
            return View(nameof(Login));
        }

        public IActionResult Registration(string returnUrl)
        {
            return View(new RegistrationData() { ReturnUrl = returnUrl });
        }
        [HttpPost]
        public IActionResult Registration(RegistrationData registrationData)
        {
            if (ModelState.IsValid)
            {
                User user = new User
                {
                    Name = registrationData.Name,
                    Age = registrationData.Age,
                    Email = registrationData.Email,
                    UserName = registrationData.Email                  
                };

                var result = userManager.CreateAsync(user, registrationData.Password).Result;
                if (result.Succeeded)
                {
                    signInManager.SignInAsync(user, false).Wait();

                    userManager.AddToRoleAsync(user, Constants.UserRoleName).Wait();

                    return Redirect(registrationData.ReturnUrl ?? "/Home");                    
                }
                else
                {
                    foreach(var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }                    
                }
            }
            return View(registrationData);
        }

        public IActionResult Logout(string returnUrl)
        {
            signInManager.SignOutAsync().Wait();
            return RedirectToAction(nameof(HomeController.Index), "Home");
        }

        public IActionResult Index(string userName)
        {
            var user = userManager.FindByNameAsync(userName).Result;
            return View(user.ToAddUserViewModel());
        }

        [HttpPost]
        public IActionResult SaveProfileImage(AddUserViewModel user)
        {
            var imagePath = imagesProvider.SaveFile(user.UploadedFile, ImagesFolders.profiles);
            var 
        }




    }
}
