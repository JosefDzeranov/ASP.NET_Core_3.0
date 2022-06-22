using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using OnlineShopWebApp.Helpers;
using OnlineShopWebApp.Interface;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrdersStorage ordersStorage;

        private readonly ICartsStorage cartsStorage;

        public OrderController(IOrdersStorage ordersStorage, ICartsStorage cartsStorage)
        {
            this.ordersStorage = ordersStorage;

            this.cartsStorage = cartsStorage;
        }

        public IActionResult Index()
        {
            var order = cartsStorage.TryGetByUserId(Constants.UserId);
            
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

            var cart = cartsStorage.TryGetByUserId(Constants.UserId);
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
