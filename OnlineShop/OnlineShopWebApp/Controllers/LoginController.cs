using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Models.Users;
using OnlineShopWebApp.Interfase;

namespace OnlineShopWebApp.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUserManager userManager;
        public LoginController(IUserManager userManager)
        {
            this.userManager = userManager;
        }
        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Registration(User user)
        {
            if (userManager.FindByLogin(user.Login) != null)
            {
                ModelState.AddModelError("", "Такой аккаунт уже существует");
            }
            if (ModelState.IsValid)
            {
                userManager.Add(user);
                return RedirectToAction("Index");
            }
            return Content("errorValid");
            
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

        public IActionResult TabooAccess()
        {
            return View();
        }
    }
}
