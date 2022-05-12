using System;
using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class OrderController : Controller
    {
        private readonly IOrderStorage _orderStorage;
        public OrderController(IOrderStorage orderStorage)
        {
            _orderStorage = orderStorage;
        }
        public IActionResult Index()
        {
            var orders = _orderStorage.GetOrderData();
            if (orders.Count == 0)
            {
                return View("Empty");
            }
            return View (orders);
        }

        public IActionResult Details(Guid id)
        {
            var order = _orderStorage.TryGetById(id);
            return View(order);
        }

        [HttpPost]
        public IActionResult UpdateOrderStatus(Guid id, OrderStatus status)
        {
            _orderStorage.UpdateStatus(id, status);
            return RedirectToAction("Index");
        }
    }
}
