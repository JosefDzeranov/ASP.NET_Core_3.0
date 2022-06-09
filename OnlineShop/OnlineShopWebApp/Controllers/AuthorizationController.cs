using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.DB;
using OnlineShop.DB.Models;
using OnlineShopWebApp.Models;
using System.Linq;

namespace OnlineShopWebApp.Controllers
{
    public class AuthorizationController : Controller
    {
        private readonly IUserBase _userBase;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public AuthorizationController(IUserBase userBase, SignInManager<User> signInManager, UserManager<User> userManager)
        {
            _userBase = userBase;
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public bool Authentification(Authorization authorization)
        {
            if (_userBase.AllUsers().Any(x => x.Login == authorization.Name && x.PasswordHash == authorization.Password))
            {
                return true;
            }
            return false;
        }

        [HttpPost]
        public IActionResult Authorize(Authorization authorization)
        {

            if (ModelState.IsValid)
            {
                var result = Authentification(authorization);
                if (result == true)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("Password", "Неправильный логин или пароль");
                }
            }
            return View("Index");
        }
    }
}
