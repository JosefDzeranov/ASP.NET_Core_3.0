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


        public IActionResult Authorization(string returnUrl)
        {
            return View(new EnterData() { ReturnUrl = returnUrl } );
        }

        [HttpPost]
        public IActionResult Authorization(EnterData enterData)
        {
            if (ModelState.IsValid)
            {
                var result = _signInManager.PasswordSignInAsync(enterData.Login, enterData.Password, enterData.Remember, false).Result;
                if (result.Succeeded)
                {
                    return RedirectToAction(enterData.ReturnUrl);
                }
                else
                {
                   ModelState.AddModelError("", "Неверный логин или пароль");
                }                
            }
            return View(nameof(Authorization));
        }

        public IActionResult Registration()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Registration(RegistrationData registrationData)
        {
            if (ModelState.IsValid)
            {
                usersRepository.Add(new UserAccount
                {
                    Login = registrationData.Login,
                    Password = registrationData.Password,
                    Name = registrationData.Name,
                    Age = registrationData.Age,
                    Email = registrationData.Email
                });
                return RedirectToAction(nameof(HomeController.Index), "Home");
            }
            else
            {
                return View(registrationData);
            }
        }
    }
}
