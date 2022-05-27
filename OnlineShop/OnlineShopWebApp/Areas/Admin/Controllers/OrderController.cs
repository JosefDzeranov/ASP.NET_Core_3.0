using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using OnlineShop.Db.Models;
using OnlineShopWebApp.Helpers;
using OnlineShopWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShopWebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class OrderController : Controller
    {
        private readonly IOrdersRepository ordersRepository;

        public OrderController(IOrdersRepository ordersRepository)
        {
            this.ordersRepository = ordersRepository;
        }

        public IActionResult Orders()
        {
            var orders = ordersRepository.GetAll();
            return View(orders.ToOrderViewModels());
        }

        public IActionResult Details(Guid orderId)
        {
            var order = ordersRepository.TryGetById(orderId);
            return View(Mapping.ToOrderViewModel(order));
        }

        [HttpPost]
        public IActionResult UpdateState(Guid orderId, OrderStateViewModel state)
        {
            ordersRepository.UpdateState(orderId, (OrderState)(int)state);
            return RedirectToAction("Orders");
        }
    }
}
