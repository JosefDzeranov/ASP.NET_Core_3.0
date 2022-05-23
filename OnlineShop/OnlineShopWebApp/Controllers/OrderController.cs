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
        public IActionResult Buy(UserDeliveryInfo user)
        {
            //if (ModelState.IsValid)
            //    return View("Index", user);

            var existingCart = cartRepository.TryGetByUserId(Constants.UserId);
            var order = new Order
            {
                User = user,
                Items = existingCart.Items,
            };
            ordersRepository.Add(order);
            cartRepository.Clear(Constants.UserId);
            return RedirectToAction("Index");
        }
    }
}
