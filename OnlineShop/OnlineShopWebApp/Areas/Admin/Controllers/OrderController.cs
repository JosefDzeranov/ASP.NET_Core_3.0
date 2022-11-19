using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.db;
using OnlineShop.db.Models;
using OnlineShopWebApp.Helpers;

namespace OnlineShopWebApp.Areas.Admin.Controllers
{
    [Area(Constants.AdminRoleName)]
    [Authorize(Roles = Constants.AdminRoleName)]
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
            return View(Mapping.ToOrderViewModels(orders).ToList());
        }

        public IActionResult Detail(int orderId)
        {
            var order = ordersRepository.TryGetById(orderId);
            return View(Mapping.ToOrderViewModel(order));
        }

        public IActionResult UpdateOrderStatus(int orderId, OrderStatus status)
        {
            ordersRepository.UpdateStatus(orderId, status);
            return RedirectToAction(nameof(Index));
        }
    }
}
