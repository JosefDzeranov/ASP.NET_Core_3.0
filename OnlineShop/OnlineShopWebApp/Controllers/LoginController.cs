using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Enter(User user)
        {
            throw new System.NotImplementedException();
        }
        [HttpPost]
        public IActionResult NewUser(User user)
        {
            throw new System.NotImplementedException();
        }
    }
}
