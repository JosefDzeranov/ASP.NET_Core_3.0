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
            var order = _orderStorage.TryGetByUserId(Constants.UserId);
            return View(order);
        }

        public IActionResult Add()
        {
            var basket = _basketStorage.TryGetByUserId(Constants.UserId);           
            _orderStorage.AddOrder(Constants.UserId, basket);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Buy()
        {
           var order = _orderStorage.TryGetByUserId(Constants.UserId);
           // order.Delivery = delivery;
            _orderStorage.SaveOrderToXmlFile(order);
            _basketStorage.ClearBasket(Constants.UserId);
            return View();
        }
    }
}
