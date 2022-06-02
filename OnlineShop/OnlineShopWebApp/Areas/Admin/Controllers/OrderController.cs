using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Models;
using System;

namespace OnlineShopWebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class OrderController : Controller
    {
        private readonly IOrderRepository orderRepository;

        public OrderController(IOrderRepository orderRepository)
        {
            this.orderRepository = orderRepository;
        }

        public IActionResult Orders()
        {
            var orders = orderRepository.GetAll();
            if (orders == null || orders.Count == 0)
                return View("notFound");
            return View(orders);
        }

        public IActionResult OrderDetails(Guid orderId)
        {
            var order = orderRepository.TryGetById(orderId);
            return View(order);
        }

        public IActionResult UpdateOrderStatus(Guid orderId, OrderStatus status)
        {
            orderRepository.UpdateStatus(orderId, status);
            return RedirectToAction("Orders");
        }
    }
}
