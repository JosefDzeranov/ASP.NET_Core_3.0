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
using System.Threading.Tasks;

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

        public async Task<IActionResult> Index()
        {
            var userId = (await userManager.FindByNameAsync(User.Identity.Name)).Id;
            var existingCart = await cartRepository.TryGetByUserIdAsync(userId);

            var orderVM = new OrderViewModel();
            orderVM.Cart = existingCart.MappingToCartViewModel();
            return View(orderVM);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(OrderViewModel orderViewModel)
        {
            if (ModelState.IsValid)
            {
                var userId = (await userManager.FindByNameAsync(User.Identity.Name)).Id;
                var existingCart = await cartRepository.TryGetByUserIdAsync(userId);
                var order = orderViewModel.MappingToOrder(existingCart);
                await orderRepository.AddAsync(order);
                await cartRepository.ClearAsync(userId);
                return View();
            }
            return RedirectToAction("Index", "Order");
        }

       
    }
}
