using System;
using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Models;
using OnlineShop.Db;
using OnlineShop.Db.Models;
using OnlineShopWebApp.Helpers;

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
            var orders = _orderStorage.GetAll();
            var orderViewModels = orders.ToOrderViewModels();
            if (orderViewModels.Count == 0)
            {
                return View("Empty");
            }
            return View (orderViewModels);
        }

        public IActionResult Details(Guid id)
        {
            var order = _orderStorage.TryGetById(id);
            var orderViewModel = order.ToOrderViewModel();
            return View(orderViewModel);
        }

        [HttpPost]
        public IActionResult UpdateStatus(Guid id, OrderStatusViewModel status)
        {
            var newStatus = (OrderStatus)status;
            _orderStorage.UpdateStatus(id, newStatus);
            return RedirectToAction("Index");
        }
    }
}
