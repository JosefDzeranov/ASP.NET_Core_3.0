using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.DB;
using OnlineShop.DB.Models;
using OnlineShopWebApp.Models;
using OnlineShopWebApp.Services;
using System;
using System.Threading.Tasks;

namespace OnlineShopWebApp.Areas.Admin.Controllers
{
    [Area(Const.AdminRoleName)]
    [Authorize(Roles=Const.AdminRoleName)]
    public class OrderController : Controller
    {
        private readonly IOrderRepository orderRepository;

        public OrderController(IOrderRepository orderRepository)
        {
            this.orderRepository = orderRepository;
        }

        public async Task<IActionResult> Index()
        {
            var ordersDb = await orderRepository.TryGetAllAsync();
            var ordersViewModel = ordersDb.MappingListOrderViewModel();
            return View(ordersViewModel);
        }

        public async Task<IActionResult> OrderDetailsAsync(Guid orderId)
        {
            var order = await orderRepository.TryGetByIdAsync(orderId);
            if (order!= null)
            {
                return View(order.MappingToOrderViewModel());
            }
            return RedirectToAction("Index", "Order");
        }

        public async Task<IActionResult> UpdateOrderStatusAsync(Guid orderId, OrderStatus status)
        {
            await orderRepository.UpdateStatusAsync(orderId, status);

            return RedirectToAction("OrderDetails", "Order", new { orderId });
        }
    }
}
