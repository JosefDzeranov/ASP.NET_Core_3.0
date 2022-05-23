using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Filters;
using OnlineShopWebApp.Interfase;

namespace OnlineShopWebApp.Controllers
{
    [ServiceFilter(typeof(CheckingForAuthorization))]
    public class UserController : Controller
    {
        private readonly IUserManager userManager;
        public UserController(IUserManager buyerManager)
        {
            this.userManager = buyerManager;
        }
        public IActionResult Index()
        {
            if (userManager.GetLoginAuthorizedUser() == null)
            {
                return RedirectToAction("Index", "Login");
            }
            var user = userManager.FindByLogin(userManager.GetLoginAuthorizedUser());
            return View(user);
        }

    }
}
