using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Models;
using OnlineShopWebApp.Services;
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

            return View(existingCart);
        }

        public IActionResult Create(string firstname, string lastname, string email, string phone, string address)
        {
            var existingCart = cartBase.TryGetByUserId(Const.UserId);
            var order = new Order()
            {
                Id = Guid.NewGuid(),
                UserId = Const.UserId,
                Cart = existingCart,
                FirstName = firstname,
                LastName = lastname,
                Email = email,
                Phone = phone,
                Address = address,

            };
            orderBase.Add(order);
            cartBase.RemoveAll(Const.UserId);
            return View();
        }

        public IActionResult Orders()
        {
            var existingOrders = orderBase.TryGetAll();

            return View(existingCart);
        }
    }
}
