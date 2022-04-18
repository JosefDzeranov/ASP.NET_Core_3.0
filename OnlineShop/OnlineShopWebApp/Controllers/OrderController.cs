using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Models;
using OnlineShopWebApp.Services;
using OnlineShopWebApp.ViewModels;
using System;

namespace OnlineShopWebApp.Controllers
{
    public class OrderController : Controller
    {
<<<<<<< HEAD
        private readonly ICartBase cartBase;
        private readonly IOrderBase orderBase;
        
        public OrderController(ICartBase cartBase, IOrderBase orderBase)
=======
        private readonly ICartRepository cartRepository;
        private readonly IOrderRepository orderRepository;
        public OrderController(ICartRepository cartRepository, IOrderRepository orderRepository)
>>>>>>> karpunin_lesson4_5
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
<<<<<<< HEAD
            var existingCart = cartBase.TryGetByUserId(Const.UserId);
            order.Cart = existingCart;
            orderBase.Add(order);
            cartBase.Clear(Const.UserId);



=======
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
>>>>>>> karpunin_lesson4_5
            return View();
        }

        public IActionResult Orders()
        {
            var existingOrders = orderRepository.TryGetAll();

            return View(existingOrders);
        }
    }
}
