using Microsoft.AspNetCore.Mvc;
using OnlineShop.DB.Models;
using OnlineShopWebApp.Models;
using OnlineShopWebApp.Services;
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

        public IActionResult Index()
        {
            var existingOrders = orderRepository.TryGetAll();

            return View(existingOrders);
        }

        public IActionResult OrderDetails(Guid orderId)
        {
            var order = orderRepository.TryGetById(orderId);
            if (order!= null)
            {
                return View(order);
            }
            return RedirectToAction("Index", "Order");
        }

        public IActionResult UpdateOrderStatus(Guid orderId, OrderStatus status)
        {
            orderRepository.UpdateStatus(orderId, status);

            return RedirectToAction("OrderDetails", "Order", new { orderId });
        }
    }
}
