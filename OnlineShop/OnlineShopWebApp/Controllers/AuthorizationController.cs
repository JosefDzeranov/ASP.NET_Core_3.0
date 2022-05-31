using Microsoft.AspNetCore.Mvc;
using OnlineShop.DB;
using OnlineShopWebApp.Models;
using System.Linq;

namespace OnlineShopWebApp.Controllers
{
    public class AuthorizationController : Controller
    {
        private readonly IUserBase _userBase;

        public AuthorizationController(IUserBase userBase)
        {
            _userBase = userBase;
        }

        public IActionResult Index()
        {
            return View();
        }

        public bool Authentification(Authorization authorization)
        {
            if (_userBase.AllUsers().Any(x => x.Login == authorization.Name && x.Password == authorization.Password))
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
