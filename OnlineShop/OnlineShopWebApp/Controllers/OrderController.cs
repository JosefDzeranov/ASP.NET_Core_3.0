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
            if (IsAuthenticated())
            {
                var userId = GetUserId();
                var existingCart = cartRepository.TryGetByUserId(userId);
                var orderVM = new OrderViewModel();
                orderVM.Cart = existingCart.MappingToCartViewModel();
                return View(orderVM);
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }

           
        }

        [HttpPost]
        public IActionResult Create(OrderViewModel orderViewModel)
        {
            if (ModelState.IsValid)
            {

                var userId = GetUserId();
                var existingCart = cartRepository.TryGetByUserId(userId);
                var order = orderViewModel.MappingToOrder(existingCart);
                orderRepository.Add(order);
                cartRepository.Clear(userId);

                return View();
            }
            return RedirectToAction("Index", "Order");
        }

        private string GetUserId()
        {
            string userId;
            if (IsAuthenticated())
            {
                userId = userManager.GetUserAsync(HttpContext.User).Result.Id;
            }
            else
            {
                userId = HttpContext.Request.Cookies["tempId"];

            }
            return userId;
        }

        private bool IsAuthenticated()
        {
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                return true;
            }
            return false;
        }
    }
}
