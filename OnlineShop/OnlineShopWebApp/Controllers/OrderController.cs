using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Models;
using OnlineShopWebApp.Helpers;
using OnlineShop.Db;
using Microsoft.AspNetCore.Authorization;

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

        [Authorize]
        public IActionResult Index()
        {
            var userId = HttpContext.Request.Cookies["userId"];
            var basket = _basketStorage.TryGetByUserId(userId);
            var basketViewModel = basket.ToBasketViewModel();
            var orderForm = new OrderFormViewModel
            {
                Basket = basketViewModel
            };

            return View(orderForm);
        }

        [HttpPost]
        public IActionResult Buy(OrderFormViewModel orderForm)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }

            var userId = HttpContext.Request.Cookies["userId"];
            var basket = _basketStorage.TryGetByUserId(userId);
            var deliveryInfo = orderForm.DeliveryInfo.ToDeliveryInfo();
            _orderStorage.Add(userId, basket, deliveryInfo);
            _basketStorage.Clear(userId);
            return View();
        }
    }
}
