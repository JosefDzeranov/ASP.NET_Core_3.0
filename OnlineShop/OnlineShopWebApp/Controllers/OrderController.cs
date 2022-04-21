using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderStorage _orderStorage;
        private readonly IBasketStorage _basketStorage;

        public OrderController(IOrderStorage orderStorage, IBasketStorage basketStorage)
        {
            _orderStorage = orderStorage;
            _basketStorage = basketStorage;
        }
        public IActionResult Index()
        {
            var basket = _basketStorage.TryGetByUserId(Constants.UserId);
            return View(basket);
        }

        [HttpPost]
        public IActionResult Buy(Delivery delivery)
        {
            var basket = _basketStorage.TryGetByUserId(Constants.UserId);
            _orderStorage.AddOrder(Constants.UserId, basket, delivery);
            var order = _orderStorage.TryGetByUserId(Constants.UserId);
            _orderStorage.SaveOrderToXmlFile(order);
            _basketStorage.ClearBasket(Constants.UserId);
            return View();
        }
    }
}
