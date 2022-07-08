using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.db.Models;
using OnlineShopWebApp.Helpers;
using Orders;

namespace OnlineShopWebApp.Areas.Admin.Controllers
{
    [Area(Constants.AdminRoleName)]
    [Authorize(Roles = Constants.AdminRoleName)]
    public class OrderController : Controller
    {
        private readonly OrdersService ordersService;

        public OrderController(OrdersService ordersService)
        {
            this.ordersService = ordersService;
        }

        public IActionResult Index()
        {
            var orders = ordersService.GetAll();
            return View(Mapping.ToOrderViewModels(orders).ToList());
        }

        public IActionResult Detail(int orderId)
        {
            var order = ordersService.TryGetById(orderId);
            return View(Mapping.ToOrderViewModel(order));
        }

        public IActionResult UpdateOrderStatus(int orderId, OrderStatus status)
        {
            ordersService.UpdateStatus(orderId, status);
            return RedirectToAction(nameof(Index));
        }
    }
}
