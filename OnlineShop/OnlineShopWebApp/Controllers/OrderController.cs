using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using OnlineShopWebApp.Interface;
using OnlineShopWebApp.Models;
using OnlineShopWebApp.ViewModels;
using OnlineShopWebApp.Helpers;

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

        public IActionResult Add(Order order)
        {
            if (ModelState.IsValid)
            {
                var existingCart = cartsStorage.TryGetByUserId(Constants.UserId);
                //order.Cart = existingCart;
                //order.UserId = Constants.UserId;
                //order.CostOrder = existingCart.Cost;
                ordersStorage.Add(order, Constants.UserId);
                cartsStorage.RemoveCartUser(Constants.UserId);
            }

            return RedirectToAction("OrderComplete");
        }

        public IActionResult OrderMaking()
        {
            var existingCart = cartsStorage.TryGetByUserId(Constants.UserId);

            var orderVM = new OrderViewModel();
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
