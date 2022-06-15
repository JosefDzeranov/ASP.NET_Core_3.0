using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db.Models;
using OnlineShopWebApp.Interfase;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUsersManager _usersManager;
        public LoginController(IUsersManager usersManager)
        {
            _usersManager = usersManager;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(UserAutorized userInput)
        {
            var user = _usersManager?.Find(userInput.Login);
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
                _usersManager.Authorized(userInput);
                return RedirectToAction(actionName:"Index",controllerName: "User");
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
            if (_usersManager.Find(userInput.Login) != null)
            {
                ModelState.AddModelError("", "Такой аккаунт уже существует");
            }
            if (ModelState.IsValid)
            {
                _usersManager.Add(userInput);
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

        public IActionResult Exit()
        {
            _usersManager.Exit();
            return RedirectToAction("Index");
        }
    }
}
