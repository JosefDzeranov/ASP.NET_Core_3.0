using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Models;
using OnlineShopWebApp.Services;
using System;

namespace OnlineShopWebApp.Controllers
{
    public class OrderController : Controller
    {
        private readonly ICartRepository cartRepository;
        private readonly IOrderRepository orderRepository;
        public OrderController(ICartRepository cartRepository, IOrderRepository orderRepository)
        {
            this.cartRepository = cartRepository;
            this.orderRepository = orderRepository;
        }

        public IActionResult Index()
        {
            var existingCart = cartRepository.TryGetByUserId(Const.UserId);

            return View(existingCart);
        }

        public IActionResult Create(string firstname, string lastname, string email, string phone, string address)
        {
            var existingCart = cartRepository.TryGetByUserId(Const.UserId);
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
                Created = DateTime.Now,
                TotalCost = existingCart.TotalCost,

            };
            orderRepository.Add(order);
            cartRepository.RemoveAll(Const.UserId);
            return View();
        }

        public IActionResult Orders()
        {
            var existingOrders = orderRepository.TryGetAll();

            return View(existingOrders);
        }
    }
}
