using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Services;
using OnlineShopWebApp.Models;
using System.Collections.Generic;
using OnlineShop.db;
using OnlineShop.db.Models;
using OnlineShopWebApp.Helpers;

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

        public IActionResult Buy(OrderViewModel orderViewModel)
        {
            var cartItems = cartRepository.TryGetByUserId(Const.UserId).Items;
            //orderViewModel.CartItems = new List<CartItemViewModel>(Mapping.ToCartItemsViewModels(cartRepository.TryGetByUserId(Const.UserId).Items));
            var order = Mapping.ToOrder(orderViewModel);
            order.Items.AddRange(cartItems);
            ordersRepository.Add(order);
            cartRepository.RemoveAll(Const.UserId);
            return View();
        }
        
    }
}
