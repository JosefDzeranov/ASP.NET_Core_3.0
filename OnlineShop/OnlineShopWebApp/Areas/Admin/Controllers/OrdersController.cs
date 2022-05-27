using System;
using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Filters;
using OnlineShopWebApp.Interfase;
using OnlineShopWebApp.Models.Users.Buyer;

namespace OnlineShopWebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    [ServiceFilter(typeof(CheckingForAuthorization))]
    public class OrdersController : Controller
    {
        private readonly IBuyerManager _buyerManager;
        public OrdersController(IBuyerManager buyerManager)
        {
            _buyerManager = buyerManager;
        }
        public IActionResult Index()
        {
            var orders = _buyerManager.CollectAllOrders();
            return View(orders);
        }
        public IActionResult Details(Guid orderId)
        {
            var order = _buyerManager.FindOrderItem(orderId);
            return View(order);
        }
        [HttpPost]
        public IActionResult SaveDetails(OrderItem newOrder)
        {
            _buyerManager.UpdateOrderStatus(newOrder);
            var orderId = newOrder.Id;
            return RedirectToAction("Details", new { orderId });
        }
        
    }
}
