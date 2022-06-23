using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using OnlineShop.Db.Models;
using OnlineShopWebApp.Helpers;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        private readonly IOrdersStorage ordersStorage;
        private readonly ICartsStorage cartsStorage;
        private readonly UserManager<User> userManager;


        public OrderController(IOrdersStorage ordersStorage, ICartsStorage cartsStorage, UserManager<User> userManager)
        {
            this.ordersStorage = ordersStorage;
            this.cartsStorage = cartsStorage;
            this.userManager = userManager;
        }

        public IActionResult Index()
        {
            var userId = userManager.GetUserId(User);
            var order = cartsStorage.TryGetByUserId(userId);
            var cartViewModel = order.ToCartViewModel();
            var orderForm = new OrderFormViewModel
            {
                Cart = cartViewModel
            };

            return View(orderForm);
        }

        [HttpPost]
        public IActionResult Add(OrderViewModel order)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }

            var userId = userManager.GetUserId(User);
            var cart = cartsStorage.TryGetByUserId(userId);
            var deliveryInfo = order.DeliveryInfo.ToContactsDelivery();
            
            ordersStorage.Add(Constants.UserId, cart, deliveryInfo);
            cartsStorage.ClearCartUser(Constants.UserId);

            return View();
        }

        public IActionResult OrderMaking()
        {
            var existingCart = cartsStorage.TryGetByUserId(Constants.UserId);

            var orderVM = new ViewModels.OrderViewModel();
            //orderVM.Cart = existingCart;

            return View(orderVM);
        }

        public IActionResult OrderComplete()
        {
            var order = ordersStorage.TryGetOrderByUserId(Constants.UserId);
            return View(order);
        }
    }
}
