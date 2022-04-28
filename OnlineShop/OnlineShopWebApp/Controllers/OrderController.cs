using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Models;
using System;

namespace OnlineShopWebApp.Controllers
{
    public class OrderController : Controller
    {
        private readonly ICartsRepository cartRepository;
        private readonly IOrderRepository ordersRepository;

        public OrderController(ICartsRepository cartRepository, IOrderRepository ordersRepository)
        {
            this.cartRepository = cartRepository;
            this.ordersRepository = ordersRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Buy(Order order)
        {
            var existingCart = cartRepository.TryGetByUserId(Constants.UserId);
            ordersRepository.Add(existingCart);
            cartRepository.Clear(Constants.UserId);
            return View();
        }
    }
}
