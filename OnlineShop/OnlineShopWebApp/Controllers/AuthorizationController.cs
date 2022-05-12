using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Controllers
{
    public class AuthorizationController : Controller
    {
        private readonly IRegAndAuthManager regAndAuthManager;

        public AuthorizationController(IRegAndAuthManager regAndAuthManager)
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