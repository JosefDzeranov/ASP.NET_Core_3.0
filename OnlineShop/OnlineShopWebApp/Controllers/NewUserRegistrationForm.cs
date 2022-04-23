using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Controllers
{
    public class NewUserRegistrationFormController : Controller
    {
 
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]

        public IActionResult Registration(NewUserRegistrationForm newUserRegistrationForm)
        {
            return View("SuccessfulRegistration"); 
        }
    }
}
