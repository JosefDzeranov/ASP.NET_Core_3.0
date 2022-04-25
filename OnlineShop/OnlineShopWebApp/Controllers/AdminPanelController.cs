using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Interfase;

namespace OOnlineShopWebApp.Controllers
{

    public class AdminPanelController : Controller
    {
        public IActionResult Index(int personId)
        {
            return View();
        }
        public IActionResult Orders(int personId)
        {
            return View();
        }
        public IActionResult Users(int personId)
        {
            return View();
        }
        public IActionResult Roles(int personId)
        {
            return View();
        }
        public IActionResult Products(int personId)
        {
            return View();
        }
    }
}
