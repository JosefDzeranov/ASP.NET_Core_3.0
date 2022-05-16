using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Models.Users;

namespace OnlineShopWebApp.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Registration(User user)
        {
            if (ModelState.IsValid)
            {
                return Content($"{user.Login} - {user.Password}");
            }
            else return Content("errorValid");
        }
        [HttpPost]
        public IActionResult Enter(User user)
        {
            if (ModelState.IsValid)
            {
                return Content($"{user.Login} - {user.Password}");
            }
            else return Content("errorValid");
        }

        public IActionResult NewUser()
        {
            return View();
        }
    }
}
