using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Interface;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrdersStorage ordersStorage;

        private readonly ICartsStorage cartsStorage;

        private readonly Constants constants;

        public OrderController(ICartsStorage cartsStorage, IOrdersStorage ordersStorage)
        {
            this.cartsStorage = cartsStorage;

            this.ordersStorage = ordersStorage;
            ;
            constants = new Constants();
        }

        public IActionResult Index()
        {
            var order = ordersStorage.TryGetOrderByUserId(constants.UserId);

            return View(order);
        }

        public IActionResult Add(string userId)
        {
            //var order = ordersStorage.TryGetProduct(productId);

            ordersStorage.Add(userId);

            return View("OrderPlaced");
        }

        public IActionResult OrderMaking(string userId)
        {
            return View("OrderMaking");
            //var order = ordersStorage.TryGetOrderByUserId(userId);
            //if (userId == null)
            //{
            //    return View("OrderMaking");
            //}
            //else

            //return RedirectToAction("OrderMaking", "Order", new { a = userId });
            //return View(order);
        }
    }
}
