using Microsoft.AspNetCore.Mvc;
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


        [HttpPost]
        public IActionResult Authorize(Authorization authorization)
        {

            if (ModelState.IsValid)
            {
                var result = _userBase.Authentification(authorization);
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
