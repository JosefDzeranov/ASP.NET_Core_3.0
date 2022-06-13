using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.DB;
using OnlineShop.DB.Models;
using OnlineShopWebApp.Models;
using OnlineShopWebApp.Services;
using OnlineShopWebApp.ViewModels;

namespace OnlineShopWebApp.Controllers
{
    public class AccountController : Controller
    {

        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;
        private readonly IFilesUploader filesUploader;

        public AccountController( UserManager<User> userManager, SignInManager<User> signInManager, IFilesUploader filesUploader)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.filesUploader = filesUploader;
        }

        [HttpGet]
        public IActionResult Login(string returnUrl)
        {
            return View(new LoginViewModel(){ ReturnUrl = returnUrl});
        }
        [HttpPost]
        public IActionResult Login(LoginViewModel loginVM)
        {
            if (ModelState.IsValid)
            {
                var result = signInManager.PasswordSignInAsync(loginVM.UserName, loginVM.Password, loginVM.RememberMe,false).Result;
                if (result.Succeeded)
                {
                    if (loginVM.ReturnUrl != null)
                    {
                        return Redirect(loginVM.ReturnUrl);
                    }
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Неверный логин или пароль");
                }

            }
            return View(loginVM);
        }
        [Authorize]
        public IActionResult Logout()
        {
            signInManager.SignOutAsync().Wait();

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Register(string returnUrl)
        {
            return View(new RegisterViewModel() { ReturnUrl = returnUrl});
        }
        [HttpPost]
        public IActionResult Register(RegisterViewModel registerVM)
        {
            if (registerVM.Password == registerVM.FirstName)
            {
                ModelState.AddModelError("Name", "Имя и пароль не должны совпадать");
            }

            if (ModelState.IsValid)
            {
                var user = new User
                {
                    UserName = registerVM.FirstName,
                    Email = registerVM.Email,
                };

                var result = userManager.CreateAsync(user, registerVM.Password).Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, Const.UserRoleName).Wait();
                    signInManager.SignInAsync(user, false).Wait();
                    return Redirect(registerVM.ReturnUrl);
                }
                else
                {
                    ModelState.AddModelError("Email", "Пользователь с таким email уже зарегистрирован");
                }


            }
            return View(registerVM);
        }

        [Authorize]
        public IActionResult Profile()
        {
            var user = userManager.FindByNameAsync(User.Identity.Name).Result;
            var userProfileViewModel = user.MappingToUserProfileViewModel();
            return View(userProfileViewModel);
        }
        [Authorize] 
        public IActionResult EditProfile()
        {
            var user = userManager.FindByNameAsync(User.Identity.Name).Result;
            var userProfileViewModel = user.MappingToUserProfileViewModel();
            return View(userProfileViewModel);
        }

        [Authorize]
        [HttpPost]
        public IActionResult EditProfile(UserProfileViewModel userProfileViewModel)
        {

            if (ModelState.IsValid)
            {
                var imagePath = filesUploader.SaveFile(userProfileViewModel.UploadedImage, Const.AvatarDirectory);
                var existingUser = userManager.FindByNameAsync(User.Identity.Name).Result;
                var user = userProfileViewModel.MappingToUser(existingUser, imagePath);
                userManager.UpdateAsync(user).Wait();

                return RedirectToAction("Profile", "Account");
            }
            
           return View(userProfileViewModel);
           
        }
    }
}
