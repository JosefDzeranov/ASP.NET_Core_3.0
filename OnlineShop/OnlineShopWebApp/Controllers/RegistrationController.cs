using Domains;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.DB;
using System.Linq;
using ViewModels;

namespace OnlineShopWebApp.Controllers
{
    public class RegistrationController : Controller
    {

        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public RegistrationController(UserManager<User> userManager, SignInManager<User> signInManager = null)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public IActionResult Index(string returnUrl = null)
        {
            return View(new Registration() { ReturnUrl = returnUrl });
        }

        private void AddNewUser(Registration registration)
        {
            var resultForUser = _userManager.CreateAsync(registration.ToUser(registration.Login), registration.Password).Result;
            if (resultForUser.Succeeded)
            {
                _userManager.AddToRoleAsync(registration.ToUser(registration.Login), Const.UserRoleName).Wait();
            }
        }

        private bool CheckName(Registration registration)
        {
            var user = registration.ToUser(registration.Login);
            bool flag = _userManager.Users.Any(x => x.UserName == user.UserName);
            if (flag == true)
            {
                return true;
            }
            else return false;
        }

        [HttpPost]
        public IActionResult Registrate(Registration registration)
        {
            if (ModelState.IsValid)
            {
                if (CheckName(registration) == false)
                {
                    AddNewUser(registration);
                    _signInManager.PasswordSignInAsync(registration.Login, registration.Password, true, false).Wait();
                    if (registration.ReturnUrl != null)
                    {
                        return Redirect(registration.ReturnUrl);
                    }
                }
                else
                {
                    ModelState.AddModelError("Login", "Такой логин уже есть. Введите другой");
                }
                return View("Index", registration);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
    }
}
