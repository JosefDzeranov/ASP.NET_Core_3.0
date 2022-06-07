using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db.Models;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUsersRepository usersRepository;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public AccountController(IUsersRepository usersRepository, UserManager<User> userManager, SignInManager<User> signInManager)
        {
            this.usersRepository = usersRepository;
            _userManager = userManager;
            _signInManager = signInManager;
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
                var result = _signInManager.PasswordSignInAsync(enterData.Login, enterData.Password, enterData.Remember, false).Result;
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

                var result = _userManager.CreateAsync(user, registrationData.Password).Result;
                if (result.Succeeded)
                {
                    _signInManager.SignInAsync(user, false).Wait();
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
            _signInManager.SignOutAsync().Wait();
            return RedirectToAction(nameof(HomeController.Index), "Home");
        }
    }
}
