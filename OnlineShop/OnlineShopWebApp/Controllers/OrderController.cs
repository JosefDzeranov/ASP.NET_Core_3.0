using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Models;
using OnlineShopWebApp.Services;
using OnlineShopWebApp.ViewModels;
using System;

namespace OnlineShopWebApp.Controllers
{
    public class OrderController : Controller
    {
        private readonly ICartBase cartBase;
        private readonly IOrderBase orderBase;
        
        public OrderController(ICartBase cartBase, IOrderBase orderBase)
        {
            this.cartBase = cartBase;
            this.orderBase = orderBase;
        }

        public IActionResult Index()
        {
            var existingCart = cartBase.TryGetByUserId(Const.UserId);

            var orderVM = new OrderVM();
            orderVM.Cart = existingCart;

            return View(orderVM);
        }

        [HttpPost]
        public IActionResult Create(Order order)
        {
            var existingCart = cartBase.TryGetByUserId(Const.UserId);
            order.Cart = existingCart;
            orderBase.Add(order);
            cartBase.RemoveAll(Const.UserId);



            return View();
        }

        public IActionResult Orders()
        {
            var existingOrders = orderBase.TryGetAll();

            return View(existingOrders);
        }
    }
}
