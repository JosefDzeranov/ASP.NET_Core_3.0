using Microsoft.AspNetCore.Mvc;

namespace OnlineShopWebApp.Areas.User.Controllers
{
    [Area("User")]

    public class RegisterController : Controller
    {

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(User user)
        {
            if (user.Password == user.PasswordConfirm)
            {
                ModelState.AddModelError("", "Passwords should match.");
            }

            if (ModelState.IsValid)
            {
                return Content($"{user.Login} - not valid");
            }

            return RedirectToAction("Index", "Home", new { area = "" });
        }
    }
}
