using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Services;
using OnlineShopWebApp.Models;
using OnlineShop.db;
using OnlineShopWebApp.Helpers;
using Microsoft.AspNetCore.Authorization;

namespace OnlineShopWebApp.Controllers
{
    [Authorize]
    public class OrderCompleteController : Controller
    {
        private readonly ICartRepository cartRepository;
        private readonly ICustomerProfile customerProfile;
        private readonly IOrdersRepository ordersRepository;
        private readonly UserDbRepository userDbRepository;
        
        // add user repository

        public OrderCompleteController(ICartRepository cartRepository, ICustomerProfile customerProfile, IOrdersRepository ordersRepository, UserDbRepository userDbRepository)
        {
            this.cartRepository = cartRepository;
            this.customerProfile = customerProfile;
            this.ordersRepository = ordersRepository;
            this.userDbRepository = userDbRepository;
        }

        public IActionResult Index()
        {
            var currentUser = userDbRepository.TryGetByName(User.Identity.Name);
            var userViewModel = currentUser.ToUserViewModel();
            //get current user, convert to UserViewModel and send it to the view
            return View(userViewModel);
        }

        public IActionResult Buy(OrderViewModel orderViewModel)
        {
            var currentUser = userDbRepository.TryGetByName(User.Identity.Name);
            var cartItems = cartRepository.TryGetByUserId(User.Identity.Name).Items;
            var order = Mapping.ToOrder(orderViewModel);
            order.User = currentUser;
            order.Items.AddRange(cartItems);
            ordersRepository.Add(order);
            cartRepository.RemoveAll(User.Identity.Name);
            return View();
        }

    }
}
