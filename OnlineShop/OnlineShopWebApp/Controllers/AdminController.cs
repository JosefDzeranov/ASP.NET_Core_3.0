using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Services;

namespace OnlineShopWebApp.Controllers
{
    public class AdminController : Controller
    {
        private readonly IOrderRepository orderRepository;

        public AdminController(IOrderRepository orderRepository)
        {
            this.orderRepository = orderRepository;
        }

        public IActionResult Index(int id)
        {

            return View(id);
        }

    }
}
