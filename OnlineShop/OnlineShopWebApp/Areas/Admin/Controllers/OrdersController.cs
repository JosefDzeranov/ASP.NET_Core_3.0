using System;
using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Filters;
using OnlineShopWebApp.Interfase;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    [ServiceFilter(typeof(CheckingForAuthorization))]
    public class OrdersController : Controller
    {
        private readonly IOrdersManager _ordersManager;
        public OrdersController(IOrdersManager ordersManager)
        {
            _ordersManager = ordersManager;
        }
        public IActionResult Index()
        {
            var orders = _ordersManager.GetAll();
            return View(orders);
        }
        public IActionResult Details(Guid orderId)
        {
            var order = _ordersManager.Find(orderId);
            return View(order);
        }
        [HttpPost]
        public IActionResult SaveDetails(Order newOrder)
        {
            _ordersManager.UpdateOrderStatus(newOrder);
            var orderId = newOrder.Id;
            return RedirectToAction("Details", new { orderId });
        }
        
    }
}
