using Microsoft.AspNetCore.Mvc;

namespace OnlineShopWebApp.Areas.Admin.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Users()
        {
            return View();
        }
    }
}
