using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Views;
using OnlineShopWebApp.Models;
using OnlineShopWebApp.Services;

namespace OnlineShopWebApp.Controllers
{
    public class AuthorizationFormController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login (UserCredentials userCredentials)
        {
            return View("SuccessfulAuthorization");
        }
    }
}
