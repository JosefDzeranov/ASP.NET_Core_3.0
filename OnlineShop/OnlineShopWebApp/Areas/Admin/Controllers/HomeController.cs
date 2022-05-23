using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Filters;

namespace OnlineShopWebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    [ServiceFilter(typeof(CheckingForAuthorization))]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
