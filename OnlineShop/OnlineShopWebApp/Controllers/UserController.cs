using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Filters;
using OnlineShopWebApp.Interfase;

namespace OnlineShopWebApp.Controllers
{
    [ServiceFilter(typeof(CheckingForAuthorization))]
    public class UserController : Controller
    {
        private readonly IUserManager _userManager;
        public UserController(IUserManager buyerManager)
        {
            _userManager = buyerManager;
        }
        public IActionResult Index()
        {
            if (_userManager.GetLoginAuthorizedUser() == null)
            {
                return RedirectToAction("Index", "Login");
            }
            var user = _userManager.FindByLogin(_userManager.GetLoginAuthorizedUser());
            return View(user);
        }

    }
}
