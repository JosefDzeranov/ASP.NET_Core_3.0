using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Controllers
{
    public class RegistrationController : Controller
    {
        private readonly IUsersManager regAndAuthManager;

        public RegistrationController(IUsersManager regAndAuthManager)
        {
            this.regAndAuthManager = regAndAuthManager;
        }
        public IActionResult Index()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Register(Registration registration)
        {
            if (ModelState.IsValid)
            {
                regAndAuthManager.RegisterUser(registration);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return RedirectToAction("Index");
            }
            
        }

    }

}