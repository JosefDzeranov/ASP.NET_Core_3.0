using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.DB;
using OnlineShop.DB.Models;
using OnlineShop.DB.Services;
using OnlineShopWebApp.Models;
using OnlineShopWebApp.Services;
using OnlineShopWebApp.ViewModels;
using System;

namespace OnlineShopWebApp.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {

        private readonly ICartRepository cartRepository;
        private readonly IOrderRepository orderRepository;
        private readonly UserManager<User> userManager;
        public OrderController(ICartRepository cartRepository, IOrderRepository orderRepository, UserManager<User> userManager)
        {
            this.cartRepository = cartRepository;
            this.orderRepository = orderRepository;
            this.userManager = userManager;
        }

        public IActionResult Index()
        {
            var userId = userManager.FindByNameAsync(User.Identity.Name).Result.Id;
            var existingCart = cartRepository.TryGetByUserId(userId);

            var orderVM = new OrderViewModel();
            orderVM.Cart = existingCart.MappingToCartViewModel();
            return View(orderVM);
        }

        [HttpPost]
        public IActionResult Create(OrderViewModel orderViewModel)
        {
            if (ModelState.IsValid)
            {
                var userId = userManager.FindByNameAsync(User.Identity.Name).Result.Id;
                var existingCart = cartRepository.TryGetByUserId(userId);
                var order = orderViewModel.MappingToOrder(existingCart);
                orderRepository.AddAsync(order);
                cartRepository.Clear(userId);
                return View();
            }
            return RedirectToAction("Index", "Order");
        }

       
    }
}
