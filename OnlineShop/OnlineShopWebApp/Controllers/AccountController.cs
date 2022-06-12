using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.db.Models;
using OnlineShopWebApp.Models;



namespace OnlineShopWebApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public AccountController(IUsersManager usersManager, UserManager<User> userManager,
            SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
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
    }
}

