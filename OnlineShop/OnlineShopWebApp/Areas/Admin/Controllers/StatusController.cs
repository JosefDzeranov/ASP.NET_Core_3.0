using Microsoft.AspNetCore.Mvc;

namespace OnlineShopWebApp.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class StatusController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }        
    }
}
