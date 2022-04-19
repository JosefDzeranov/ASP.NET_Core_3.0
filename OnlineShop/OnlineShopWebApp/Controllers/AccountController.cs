using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.ViewModels;

namespace OnlineShopWebApp.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(LoginVM loginVM)
        {
            return View();
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
    }
}
