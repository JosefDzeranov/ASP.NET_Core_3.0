using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Services;
using OnlineShopWebApp.Models;
using OnlineShopWebApp.Areas.Admin.Models;

namespace OnlineShopWebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class OrderController : Controller
    {
  
        private readonly IOrdersRepository ordersRepository;


        public OrderController(IOrdersRepository ordersRepository)
        { 

            this.ordersRepository = ordersRepository;

        }

        public IActionResult Index()
        {
            var orders = ordersRepository.GetAll();
            return View(orders);
        }


        public IActionResult Detail(int orderId)
        {
            var order = ordersRepository.TryGetByUserId(orderId);
            return View(order);
        }

        public IActionResult UpdateOrderStatus(int orderId, OrderStatus status)
        {
            ordersRepository.UpdateStatus(orderId, status);
            return RedirectToAction(nameof(Index));
        }
    }
}
