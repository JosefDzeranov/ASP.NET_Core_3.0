using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Models;
using OnlineShopWebApp.Services;
using OnlineShopWebApp.ViewModels;
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

            var orderVM = new OrderVM();
            orderVM.Cart = existingCart;

            return View(orderVM);
        }

        [HttpPost]
        public IActionResult Create(Order order)
        {

            var existingCart = cartRepository.TryGetByUserId(Const.UserId);
            order.Cart = existingCart;
            order.UserId = Const.UserId;
            order.TotalCost = existingCart.TotalCost;
            orderRepository.Add(order);
            cartRepository.Clear(Const.UserId);

            return View();
        }

        public IActionResult Orders()
        {
            var existingOrders = orderRepository.TryGetAll();

            return View(existingOrders);
        }
    }
}
