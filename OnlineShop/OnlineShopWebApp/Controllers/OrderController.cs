using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Interface;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrdersStorage ordersStorage;

        public OrderController(IOrdersStorage ordersStorage)
        {
            this.ordersStorage = ordersStorage;
        }

        public IActionResult Index()
        {
            var order = ordersStorage.TryGetOrderByUserId(Constants.UserId);

            return View(order);
        }

        public IActionResult Add(Order order, Customer customer)
        {
            ordersStorage.Add(order, customer, Constants.UserId);

            //var order2 = ordersStorage.TryGetOrderByUserId(Constants.UserId);

            return RedirectToAction("OrderComplete");
        }

        public IActionResult OrderMaking()
        {
            return View();
        }

        public IActionResult OrderComplete()
        {
            var order = ordersStorage.TryGetOrderByUserId(Constants.UserId);

            return View(order);
        }
    }
}
