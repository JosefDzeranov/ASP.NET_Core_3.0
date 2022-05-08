using Microsoft.AspNetCore.Mvc;

namespace OnlineShopWebApp.Areas.User.Controllers
{
    [Area("User")]

    public class LoginController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult Login(User user)
        {
            if (user.Login == "Login")
            {
                ModelState.AddModelError("", "Please enter unique Login.");
            }

            if (ModelState.IsValid)
            {
                return Content($"{user.Login} - not valid");
            }

            return RedirectToAction("Products","Home");
        }
    }
}
