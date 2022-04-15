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

        public IActionResult Create(OrderVM orderVM)
        {
            //var existingCart = cartBase.TryGetByUserId(Const.UserId);
            //var order = new Order()
            //{
            //    Id = Guid.NewGuid(),
            //    UserId = Const.UserId,
            //    Cart = existingCart,
            //    FirstName = firstname,
            //    LastName = lastname,
            //    Email = email,
            //    Phone = phone,
            //    Address = address,
            //    Created = DateTime.Now,
            //    TotalCost = existingCart.TotalCost,

            //};
            orderBase.Add(orderVM.Order);
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
