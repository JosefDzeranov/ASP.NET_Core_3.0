using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Interface;
using OnlineShopWebApp.Models;
using OnlineShopWebApp.Services;
using System;

namespace OnlineShopWebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class OrderController : Controller
    {
        private readonly IOrdersStorage ordersStorage;

        public OrderController(IOrdersStorage ordersStorage)
        {
            this.ordersStorage = ordersStorage;
        }

        public IActionResult Index()
        {
            var existingOrders = ordersStorage.TryGetOrderAllByUserId(Constants.UserId);

            return View(existingOrders);
        }

        public IActionResult GetOrder(Guid orderId)
        {
            var order = ordersStorage.TryGetOrderAllByUserId(Constants.UserId);
            if (order != null)
            {
                return View(order);
            }
            return RedirectToAction("Index", "Order");
        }

        public IActionResult SaveEditedOrder(Guid orderId, OrderState state)
        {
            ordersStorage.SaveEditedOrder(orderId, state);

            return RedirectToAction("GetOrder", "Order", new { orderId });
        }
    }
}