using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Models;
using OnlineShop.db;
using OnlineShopWebApp.Helpers;
using Microsoft.AspNetCore.Authorization;
using Orders;

namespace OnlineShopWebApp.Controllers
{
    [Authorize]
    public class OrderCompleteController : Controller
    {
        private readonly ICartRepository cartRepository;
        private readonly OrdersService ordersService;
        private readonly UserDbRepository userDbRepository;


        public OrderCompleteController(ICartRepository cartRepository, UserDbRepository userDbRepository, OrdersService ordersService)
        {
            this.cartRepository = cartRepository;
            this.userDbRepository = userDbRepository;
            this.ordersService = ordersService;
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
            ordersService.Add(order);
            cartRepository.RemoveAll(User.Identity.Name);
            return View();
        }

    }
}
