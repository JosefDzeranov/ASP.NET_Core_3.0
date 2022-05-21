using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Filters;

namespace OnlineShopWebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    [ServiceFilter(typeof(CheckingForAuthorization))]
    public class UsersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
