using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Areas.Admin.Models;
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

        [HttpPost]
        public IActionResult Index (NewUserRegistrationForm newUserRegistration)
        {
            if (newUserRegistration.UserName == newUserRegistration.Login)
            {
                ModelState.AddModelError("", "Имя и логин не должны совпадать");
            }
            if (ModelState.IsValid)
            {
                return Content($"{newUserRegistration.UserName}-{newUserRegistration.Login}");
            }
            return View(newUserRegistration);
        }
    }
}
