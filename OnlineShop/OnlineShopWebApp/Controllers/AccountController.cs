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
       
        public AccountController( UserManager<User> userManager, SignInManager<User> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
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
    }
}
