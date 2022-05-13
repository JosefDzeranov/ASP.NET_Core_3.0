using Microsoft.AspNetCore.Mvc;
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
            var orders = ordersStorage.TryGetOrders(Constants.UserId);

            return View(orders);
        }

        public IActionResult Add(Order order, Customer customer)
        {
            ordersStorage.Add(order, customer, Constants.UserId);

            cartsStorage.RemoveCartUser(Constants.UserId);

            return RedirectToAction("OrderComplete");
        }

        public IActionResult OrderMaking()
        {
            return View();
        }

        public IActionResult OrderComplete()
        {
            var order = ordersStorage.TryGetOrder(Constants.UserId);

            return View(order);
        }
    }
}
