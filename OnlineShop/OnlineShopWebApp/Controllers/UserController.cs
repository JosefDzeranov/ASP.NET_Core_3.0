using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Filters;
using OnlineShopWebApp.Interfase;

namespace OnlineShopWebApp.Controllers
{
    [ServiceFilter(typeof(CheckingForAuthorization))]
    public class UserController : Controller
    {
        private readonly IUsersManager _usersManager;
        public UserController(IUsersManager usersManager)
        {
            _usersManager = usersManager;
        }
        public IActionResult Index()
        {
            if (_usersManager.GetLoginAuthorizedUser() == null)
            {
                return RedirectToAction("Index", "Login");
            }
            var user = _usersManager.Find(_usersManager.GetLoginAuthorizedUser());
            return View(user);
        }

    }
}
