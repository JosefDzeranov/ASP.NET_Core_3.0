using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Services;
using OnlineShopWebApp.Models;
using System.Collections.Generic;
using OnlineShop.Db;
using OnlineShop.db.Models;

namespace OnlineShopWebApp.Controllers
{
    public class OrderCompleteController : Controller
    {
        private readonly ICartRepository cartRepository;
        private readonly ICustomerProfile customerProfile;
        private readonly IOrdersRepository ordersRepository;

        public OrderCompleteController(ICartRepository cartRepository, ICustomerProfile customerProfile, IOrdersRepository ordersRepository)
        {
            this.cartRepository = cartRepository;
            this.customerProfile = customerProfile;
            this.ordersRepository = ordersRepository;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Buy(Order order)
        {
            order.CartItems = new List<CartItem>(cartRepository.TryGetByUserId(Const.UserId).Items);
            ordersRepository.Add(order);
            cartRepository.RemoveAll(Const.UserId);
            return View();
        }

    }
}
