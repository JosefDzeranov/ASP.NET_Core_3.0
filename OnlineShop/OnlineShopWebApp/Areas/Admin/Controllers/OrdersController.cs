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
        private readonly IBuyerManager buyerManager;
        public OrdersController(IBuyerManager buyerManager)
        {
            this.buyerManager = buyerManager;
        }
        public IActionResult Index()
        {
            var orders = buyerManager.CollectAllOrders();
            return View(orders);
        }
        public IActionResult Details(Guid orderId)
        {
            var order = buyerManager.FindOrderItem(orderId);
            return View(order);
        }
        [HttpPost]
        public IActionResult SaveDetails(OrderItem newOrder)
        {
            buyerManager.UpdateOrderStatus(newOrder);
            var orderId = newOrder.Id;
            return RedirectToAction("Details", new { orderId });
        }
        
    }
}
