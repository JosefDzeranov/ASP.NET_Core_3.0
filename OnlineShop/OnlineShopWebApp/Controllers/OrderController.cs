using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Services;

namespace OnlineShopWebApp.Controllers
{
    public class OrderController : Controller
    {
        private readonly ICartBase cartBase;
        private readonly IOrderBase orderBase;
        public IActionResult Index()
        {
            return View();
        }
    }
}
