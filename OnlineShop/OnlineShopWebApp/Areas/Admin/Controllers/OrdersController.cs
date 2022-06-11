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
        private readonly IOrdersRepository _ordersRepository;
        public OrdersController(IBuyerManager buyerManager, IOrdersRepository ordersRepository)
        {
            _buyerManager = buyerManager;
            _ordersRepository = ordersRepository;
        }
        public IActionResult Index()
        {
            var orders = _ordersRepository.GetAll();
            //var orders = _buyerManager.CollectAllOrders();
            return View(orders);
        }
        public IActionResult Details(Guid orderId)
        {
            var order = _ordersRepository.FindOrderItem(orderId);
            return View(order);
        }
        [HttpPost]
        public IActionResult SaveDetails(Order newOrder)
        {
            _ordersRepository.UpdateOrderStatus(newOrder);
            var orderId = newOrder.Id;
            return RedirectToAction("Details", new { orderId });
        }
        
    }
}
