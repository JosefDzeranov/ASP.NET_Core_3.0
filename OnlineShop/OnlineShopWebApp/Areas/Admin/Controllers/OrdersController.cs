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
            var ordersVM = orders.Select(x => Mapping.ToOrder_ViewModel(x)).ToList();
            return View(ordersVM);
        }
        public IActionResult Details(Guid orderId)
        {
            var orders = _ordersRepositiry.GetAll();
            
            var order = orders.Find(order => order.Id == orderId);
            var orderVM = Mapping.ToOrder_ViewModel(order);
            return View(orderVM);
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
