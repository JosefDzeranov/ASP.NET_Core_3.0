using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Controllers
{
    public class RegistrationController : Controller
    {
        private readonly IRegAndAuthManager regAndAuthManager;

        public RegistrationController(IRegAndAuthManager regAndAuthManager)
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
                regAndAuthManager.Register(registration);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return RedirectToAction("Index");
            }
            
        }

    }

}