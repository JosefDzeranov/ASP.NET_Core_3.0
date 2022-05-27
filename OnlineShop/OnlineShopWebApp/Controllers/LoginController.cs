using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Interfase;
using OnlineShopWebApp.Models.Users;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUserManager _userManager;
        public LoginController(IUserManager userManager)
        {
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(UserAutorized userInput)
        {
            var user = _userManager?.FindByLogin(userInput.Login);
            if (user == null)
            {
                ModelState.AddModelError("", "Такого аккаунта не существует");
            }
            else if (userInput?.Password != user?.Password)
            {
                ModelState.AddModelError("", "Логин или пароль введён неверно");
            }
            if (ModelState.IsValid)
            {
                _userManager.Authorized(userInput);
                return RedirectToAction("Index", "User");
            }
            return View();
        }

        [HttpPost]
        public IActionResult Register(UserRegistration userInput)
        {
            if (userInput.Login == userInput.Password)
            {
                ModelState.AddModelError("", "Логин и пароль не должны совпадать!");
            }
            if (_userManager.FindByLogin(userInput.Login) != null)
            {
                ModelState.AddModelError("", "Такой аккаунт уже существует");
            }
            if (ModelState.IsValid)
            {
                _userManager.Add(userInput);
                _userManager.AssignRole(userInput.Login, MyConstant.RoleDefaultId); //Покупатель
                return RedirectToAction("Index", "User");
            }
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        public IActionResult TabooAccess()
        {
            return View();
        }
    }
}
