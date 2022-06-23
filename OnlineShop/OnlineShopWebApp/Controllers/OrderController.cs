using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Models;
using OnlineShopWebApp.Helpers;
using OnlineShop.Db;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using OnlineShop.Db.Models;

namespace OnlineShopWebApp.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderStorage _orderStorage;
        private readonly IBasketStorage _basketStorage;
        private readonly UserManager<User> _userManager;

        public OrderController(IOrderStorage orderStorage, IBasketStorage basketStorage, UserManager<User> userManager)
        {
            _orderStorage = orderStorage;
            _basketStorage = basketStorage;
            _userManager = userManager;
        }

        [Authorize]
        public IActionResult Index()
        {
            var userId = _userManager.GetUserId(User);
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

            var userId = _userManager.GetUserId(User);
            var basket = _basketStorage.TryGetByUserId(userId);
            var deliveryInfo = orderForm.DeliveryInfo.ToDeliveryInfo();
            _orderStorage.Add(userId, basket, deliveryInfo);
            _basketStorage.Clear(userId);
            return View();
        }
    }
}
