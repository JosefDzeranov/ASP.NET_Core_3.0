using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.db;
using OnlineShop.db.Models;
using OnlineShopWebApp.Helpers;
using OnlineShopWebApp.Models;
using OnlineShopWebApp.Services;

namespace OnlineShopWebApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly ImagesProvider imagesProvider;
        private readonly IOrdersRepository ordersRepository;

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager, ImagesProvider imagesProvider, IOrdersRepository ordersRepository)
        {
            this.userManager = userManager;
            _signInManager = signInManager;
            this.imagesProvider = imagesProvider;
            this.ordersRepository=ordersRepository;
        }

        [HttpGet]
        public IActionResult Login(string returnUrl = "")
        {
            return View(new UserCredentials() { ReturnUrl = returnUrl });
        }

        [HttpPost]
        public IActionResult Login(UserCredentials userCredentials)
        {
            if (ModelState.IsValid)
            {
                var result = _signInManager.PasswordSignInAsync(userCredentials.Login, userCredentials.Password,
                    userCredentials.RememberMe, false).Result;

                if (result.Succeeded)
                {
                    return Redirect(userCredentials.ReturnUrl ?? "/Home");
                }
                else
                {
                    ModelState.AddModelError("", "Неверный логин или пароль");
                }
            }
            return View(nameof(Login), userCredentials);
        }

        public IActionResult Logout(string returnUrl)
        {
            _signInManager.SignOutAsync().Wait();
            return RedirectToAction(nameof(HomeController.Index), "Home");
        }

        [Authorize]
        public IActionResult Profile()
        {
            var user = userManager.FindByNameAsync(User.Identity.Name).Result;
            var userProfileViewModel = user.ToUserViewModel();
            return View(userProfileViewModel);
        }
        [Authorize]
        public IActionResult Edit()
        {
            var user = userManager.FindByNameAsync(User.Identity.Name).Result;
            var userProfileViewModel = user.ToUserViewModel();
            return View(userProfileViewModel);
        }

        [Authorize]
        [HttpPost]
        public IActionResult Edit(UserViewModel userProfile)
        {
            ModelState.Remove("Password");
            ModelState.Remove("ConfirmPassword");
            if (ModelState.IsValid)
            {
                var imagePath = imagesProvider.SafeFile(userProfile.UploadedImage, ImageFolders.Profiles);
                var existingUser = userManager.FindByNameAsync(User.Identity.Name).Result;

                existingUser.Update(userProfile, imagePath);
                //var user = Mapping.ToUser(existingUser, imagePath);
                userManager.UpdateAsync(existingUser).Wait();

                return RedirectToAction("Profile", "Account");
            }

            return View(userProfile);

        }

        [Authorize]
        public IActionResult UserOrders()
        {
            var userId = userManager.FindByNameAsync(User.Identity.Name).Result.Id;
            var orders = ordersRepository.TryGetByUserId(userId);
            return View(orders.ToOrderViewModels());
        }

        public ActionResult AvatarPath()
        {
            var avatar  = userManager.FindByNameAsync(User.Identity.Name).Result.AvatarPath; 
            return Content(avatar);
        }

    }
}

