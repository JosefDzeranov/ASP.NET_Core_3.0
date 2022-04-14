using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Interface;

namespace OnlineShopWebApp.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrdersStorage ordersStorage;

        private readonly static Constants constants;

        public OrderController(IOrdersStorage ordersStorage)
        {
            this.ordersStorage = ordersStorage;
        }

        public IActionResult Index()
        {
            var order = ordersStorage.TryGetOrderByUserId(constants.UserId);

            return View(order);
        }

        public IActionResult Add(string userId, string lastname, string name, string mail, string adress, string phone)
        {
            ordersStorage.Add(userId, lastname, name, mail, adress, phone);

            var order = ordersStorage.TryGetOrderByUserId(constants.UserId);

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
