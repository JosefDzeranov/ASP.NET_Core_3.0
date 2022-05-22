using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Models;
using OnlineShop.Db;

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
        //public IActionResult Index()
        //{
        //    var basket = _basketStorage.TryGetByUserId(Constants.UserId);
        //    var orderForm = new OrderForm() { Basket = basket };

        //    return View(orderForm);
        //}

        //[HttpPost]
        //public IActionResult Buy(OrderForm orderForm)
        //{
        //    if(!ModelState.IsValid)
        //    {
        //        return RedirectToAction("Index");
        //    }

        //    var basket = _basketStorage.TryGetByUserId(Constants.UserId);
        //    var delivery = orderForm.Delivery;
        //    _orderStorage.Add(Constants.UserId, basket, delivery);

        //    _basketStorage.ClearBasket(Constants.UserId);

        //    return View();
        //}
    }
}
