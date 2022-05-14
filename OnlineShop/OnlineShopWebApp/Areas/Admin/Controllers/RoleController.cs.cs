using Microsoft.AspNetCore.Mvc;

namespace OnlineShopWebApp.Areas.Admin.Controllers
{
    public class RoleController : Controller
    {
        public IActionResult Roles()
        {
            return View();
        }
    }
}
