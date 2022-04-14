using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Interface;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrdersStorage ordersStorage;

        //private readonly ICartsStorage cartsStorage;

        private readonly static Constants constants;

        public OrderController(ICartsStorage cartsStorage, IOrdersStorage ordersStorage)
        {
           // this.cartsStorage = cartsStorage;

            this.ordersStorage = ordersStorage;

            //constants = new Constants();
        }

        public IActionResult Index()
        {
            var order = ordersStorage.TryGetOrderByUserId(constants.UserId);

            return View(order);
        }

        public IActionResult Add(string userId, string lastname, string name, string mail, string adress)
        {
            //var order = ordersStorage.TryGetProduct(productId);

            ordersStorage.Add(userId, lastname, name, mail, adress);

            return View("OrderPlaced");
        }

        public IActionResult OrderMaking(string userId)
        {
            return View("OrderMaking");
        }
    }
}
