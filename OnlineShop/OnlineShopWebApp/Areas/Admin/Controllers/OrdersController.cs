using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db.Interfase;
using OnlineShop.Db.Models;
using OnlineShopWebApp.Filters;
using OnlineShopWebApp.Helpers;
using OnlineShopWebApp.Interfase;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    [ServiceFilter(typeof(CheckingForAuthorization))]
    public class OrdersController : Controller
    {
        private readonly IOrdersRepositiry _ordersRepositiry;
        public OrdersController(IOrdersRepositiry ordersRepositiry)
        {
            _ordersRepositiry = ordersRepositiry;
        }
        public IActionResult Index()
        {
            var orders = _ordersRepositiry.GetAll();

            return View(orders.Select(x => Mapping.ToOrder_ViewModels(x)).ToList());
        }
        public IActionResult Details(Guid orderId)
        {
            var order = _ordersRepositiry.Find(orderId);
            return View(Mapping.ToOrder_ViewModels(order));
        }
        [HttpPost]
        public IActionResult SaveDetails(Order newOrder)
        {
            _ordersRepositiry.UpdateOrderStatus(newOrder);
            var orderId = newOrder.Id;
            return RedirectToAction("Details", new { orderId });
        }
        
    }
}
