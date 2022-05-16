using System;
using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Interfase;
using OnlineShopWebApp.Models.Users.Buyer;

namespace OnlineShopWebApp.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class OrdersController : Controller
    {
        private readonly IBuyerStorage buyerStorage;
        public OrdersController(IBuyerStorage buyerStorage)
        {
            this.buyerStorage = buyerStorage;
        }
        public IActionResult Index()
        {
            var orders = buyerStorage.CollectAllOrders();
            return View(orders);
        }
        public IActionResult Details(Guid orderId)
        {
            var order = buyerStorage.FindOrderItem(orderId);
            return View(order);
        }
        [HttpPost]
        public IActionResult SaveDetails(OrderItem newOrder)
        {
            buyerStorage.UpdateOrderStatus(newOrder);
            var orderId = newOrder.Id;
            return RedirectToAction("Details", new { orderId });
        }
        
    }
}
