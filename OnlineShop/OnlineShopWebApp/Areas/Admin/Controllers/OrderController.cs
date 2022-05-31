using Microsoft.AspNetCore.Mvc;
using OnlineShop.DB;
using OnlineShop.DB.Models;
using OnlineShopWebApp.Helpers;
using OnlineShopWebApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShopWebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class OrderController : Controller
    {
        private readonly IOrderBase _orderBase;

        public OrderController(IOrderBase orderBase)
        {
            _orderBase = orderBase;
        }

        public IActionResult Orders()
        {
            var orders = _orderBase.AllOrders().ToList().Select(x => x.ToOrderViewModel());
            return View(orders);
        }

        public IActionResult GetOrder(int orderId)
        {
            var necessaryOrder = _orderBase.AllOrders().FirstOrDefault(x => x.Id == orderId);
            return View(necessaryOrder);
        }

        [HttpPost]
        public IActionResult UpdateStatusOrder(int orderId, OrderStatus status)
        {
            _orderBase.UpdateOrderStatus(orderId, status);
            return RedirectToAction("Orders");
        }
    }
}
