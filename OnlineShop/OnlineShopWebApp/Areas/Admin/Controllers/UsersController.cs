using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Filters;
using OnlineShopWebApp.Interfase;

namespace OnlineShopWebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    [ServiceFilter(typeof(CheckingForAuthorization))]
    public class UsersController : Controller
    {
        private readonly IUserManager userManager;

        public UsersController(IUserManager userManager)
        {
             this.userManager = userManager;
        }
        public IActionResult Index()
        {
            var users = userManager.GetAll();
            return View(users);
        }
    }
}
