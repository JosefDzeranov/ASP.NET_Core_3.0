using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Models;
using OnlineShopWebApp.Helpers;
using OnlineShop.Db;
using OnlineShop.Db.Models;

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
            var basketViewModel = basket.ToBasketViewModel();
            var orderForm = new OrderForm
            {
                Basket = basketViewModel
            };

            return View(orderForm);
        }

        [HttpPost]
        public IActionResult Buy(OrderForm orderForm)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }

            var basket = _basketStorage.TryGetByUserId(Constants.UserId);
            var basketViewModel = basket.ToBasketViewModel();
            var delivery = orderForm.Delivery;
            _orderStorage.Add(Constants.UserId, basketViewModel, delivery);

            _basketStorage.ClearBasket(Constants.UserId);

            return View();
        }
    }
}
