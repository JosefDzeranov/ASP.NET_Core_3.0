using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Interface;

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

        public IActionResult Add(IOrdersStorage ordersStorage, Models.Order order)
        {
            ordersStorage.Add(order);

            var order = ordersStorage.TryGetOrderByUserId(Constants.UserId);

            return View(order);
        }

        public IActionResult OrderMaking()
        {
            return View();
        }

        public IActionResult OrderComplete()
        {
            return View();
        }
    }
}
