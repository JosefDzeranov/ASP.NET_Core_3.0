using Microsoft.AspNetCore.Mvc;
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
        public OrderController(ICartRepository cartRepository, IOrderRepository orderRepository)
        {
            this.cartRepository = cartRepository;
            this.orderRepository = orderRepository;
        }

        public IActionResult Index()
        {
            var existingCart = cartRepository.TryGetByUserId(Const.UserId);

            var orderVM = new OrderViewModel();
            orderVM.Cart = existingCart.MappingCartViewModel();
            return View(orderVM);
        }

        [HttpPost]
        public IActionResult Create(OrderViewModel orderViewModel)
        {
            if (ModelState.IsValid)
            {
                var existingCart = cartRepository.TryGetByUserId(Const.UserId);
                var cartView = existingCart.MappingCartViewModel();
                orderViewModel.Cart = cartView;
                orderViewModel.UserId = Const.UserId;
                orderViewModel.TotalCost = cartView.TotalCost;
                var order = orderViewModel.MappingOrder();
                orderRepository.Add(order);
                cartRepository.Clear(Const.UserId);
                return View();
            }
            return RedirectToAction("Index", "Order");
        }

       
    }
}
