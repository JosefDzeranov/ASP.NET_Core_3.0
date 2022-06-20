using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using OnlineShopWebApp.Interface;
using OnlineShopWebApp.Models;
using System;

namespace OnlineShopWebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class OrderController : Controller
    {
        private readonly IOrdersStorage ordersStorage;
        
        private readonly ICartsStorage cartsStorage;

        public OrderController(IOrdersStorage ordersStorage, ICartsStorage cartsStorage)
        {
            this.ordersStorage = ordersStorage;
            this.cartsStorage = cartsStorage;
        }

        public IActionResult Index()
        {
            var existingOrders = ordersStorage.TryGetOrderAllByUserId(Constants.UserId);

            return View(existingOrders);
        }

        public IActionResult GetOrder()
        {
            var order = ordersStorage.TryGetOrderAllByUserId(Constants.UserId);
            if (order != null)
            {
                return View(order);
            }
            return RedirectToAction("Index", "Order");
        }

        public IActionResult SaveEditedOrder(Guid orderId, OrderStateViewModel state)
        {
            ordersStorage.SaveEditedOrder(orderId, state);

            return RedirectToAction("GetOrder", "Order", new { orderId });
        }
    }
}