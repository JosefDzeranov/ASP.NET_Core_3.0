using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.db.Models;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Controllers
{
    public class RegistrationController : Controller
    {
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;

        public RegistrationController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(Registration registration)
        {
            if (registration.UserName == registration.Login)
            {
                ModelState.AddModelError("", "Имя и логин не должны совпадать");
            }

            return View("Registration", registration);
        }


        public IActionResult Register(string returnUrl)
        {
            return View(new Registration() { ReturnUrl = returnUrl });
        }


        [HttpPost]
        public IActionResult Register(Registration registration)
        {
            if (ModelState.IsValid)
            {
                User user = new User
                {
                    UserName = registration.UserName,
                    Email = registration.Login,
                    PhoneNumber = registration.Phone,

                };
                var result = userManager.CreateAsync(user, registration.Password).Result;
                if (result.Succeeded)
                {
                    signInManager.SignInAsync(user, false).Wait();
                    return Redirect(registration.ReturnUrl ?? "/Home");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }
            return View(registration);
        }

    }
}
