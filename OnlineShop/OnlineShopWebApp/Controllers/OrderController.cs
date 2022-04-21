using Microsoft.AspNetCore.Mvc;
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

        public IActionResult Buy()
        {
            var existingCarts = cartRepository.TryGetByUserId(Constants.UserId);
            ordersRepository.Add(existingCarts);
            cartRepository.Clear(Constants.UserId);
            return View();
        }
    }
}
