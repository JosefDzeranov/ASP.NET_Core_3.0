using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using OnlineShop.Db.Models;
using OnlineShopWebApp.Helpers;
using OnlineShopWebApp.Models;
using System;
using System.IO;

namespace OnlineShopWebApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;
        private readonly RoleManager<IdentityRole> rolesManager;
        private readonly ImagesProvider imagesProvider;
        private readonly IOrdersRepository ordersRepository;

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager, RoleManager<IdentityRole> rolesManager, ImagesProvider imagesProvider, IOrdersRepository ordersRepository)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.rolesManager = rolesManager;
            this.imagesProvider = imagesProvider;
            this.ordersRepository = ordersRepository;
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
                    UserName = registrationData.Email,
                    ImagePath = "/images/profiles/common.png"
                };

                var result = userManager.CreateAsync(user, registrationData.Password).Result;
                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, Constants.UserRoleName).Wait();

                    signInManager.SignInAsync(user, false).Wait();                   

                    return Redirect(registrationData.ReturnUrl ?? "/Home");
                }
                else
                {
                    foreach (var error in result.Errors)
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
        public IActionResult ChangeProfile(AddUserViewModel changedUser)
        {            
            var user = userManager.FindByNameAsync(changedUser.Email).Result;
            user.Email = changedUser.Email;
            user.Age = changedUser.Age;
            user.UserName = changedUser.Email;
            user.Name = changedUser.Name;
            if (changedUser.UploadedFile != null)
            {
                if (user.ImagePath != "/images/profiles/common.png")
                {
                    imagesProvider.Delete(user.ImagePath);
                }
                user.ImagePath = imagesProvider.SaveFile(changedUser.UploadedFile, ImagesFolders.profiles);
            }

            userManager.UpdateAsync(user).Wait();

            return RedirectToAction("Index", new { userName = user.UserName });
        }


        [HttpPost]
        public IActionResult DeleteImage(AddUserViewModel changedUser)
        {
            var user = userManager.FindByNameAsync(changedUser.Email).Result;
            user.Email = changedUser.Email;
            user.Age = changedUser.Age;
            user.UserName = changedUser.Email;
            user.Name = changedUser.Name;

            imagesProvider.Delete(user.ImagePath);

            user.ImagePath = "/images/profiles/common.png";

            userManager.UpdateAsync(user).Wait();

            return RedirectToAction("Index", new { userName = user.UserName });
        }

        
        public IActionResult Orders(string userName)
        {
            var user = userManager.FindByNameAsync(userName).Result;
            var orders = ordersRepository.TryGetByUserId(user.Id);
            return View(orders.ToOrderViewModels());
        }
    }
}
