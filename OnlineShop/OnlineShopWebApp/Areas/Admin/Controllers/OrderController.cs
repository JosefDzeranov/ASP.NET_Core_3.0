using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            var orders = _orderBase.AllOrders();
            return View(orders);
        }

        public IActionResult GetOrder(int orderId)
        {
            var necessaryOrder = _orderBase.AllOrders().FirstOrDefault(x => x.Id == orderId);
            return View(necessaryOrder);
        }

    }
}
