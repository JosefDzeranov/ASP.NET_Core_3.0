using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Controllers
{
    public class AuthorizationController : Controller
    {
        private readonly IUsersManager regAndAuthManager;

        public AuthorizationController(IUsersManager regAndAuthManager)
        {
            this.regAndAuthManager = regAndAuthManager;
        }
        public IActionResult Index()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Enter(Authorization authorization)
        {
            if (ModelState.IsValid && regAndAuthManager.Compare(authorization))
            {

                return RedirectToAction("Index", "Home");
            }
            else
            {
               return RedirectToAction("Index");
            }
            
        }

    }

}