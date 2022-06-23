using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using OnlineShop.Db.Models;
using System;

namespace OnlineShopWebApp.Areas.Admin.Controllers
{
    [Area(Constants.AdminRoleName)]
    [Authorize(Roles = Constants.AdminRoleName)]

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

            if (existingOrders.Count > 0)
            {
                return View(existingOrders);
            }
            return View();
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

        public IActionResult SaveEditedOrder(Guid orderId, OrderState state)
        {
            ordersStorage.SaveEditedOrder(orderId, state);

            return RedirectToAction("GetOrder", "Order", new { orderId });
        }
    }
}