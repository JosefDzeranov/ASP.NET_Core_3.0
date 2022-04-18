using Microsoft.AspNetCore.Mvc;

namespace OnlineShopWebApp.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderStorage _orderStorage;
        private readonly IBasketStorage _basketStorage;
        private readonly IDeliveryStorage _deliveryStorage;

        public OrderController(IOrderStorage orderStorage, IBasketStorage basketStorage, IDeliveryStorage deliveryStorage)
        {
            _orderStorage = orderStorage;
            _basketStorage = basketStorage;
            _deliveryStorage = deliveryStorage;
        }
        public IActionResult Index()
        {
            var order = _orderStorage.TryGetByUserId(Constants.UserId);
            return View(order);
        }

        public IActionResult Add()
        {
            var basket = _basketStorage.TryGetByUserId(Constants.UserId);
            var delivery = _deliveryStorage.GetDeliveryData();
            _orderStorage.AddOrder(Constants.UserId, basket, delivery);
            return RedirectToAction("Index");
        }
        public IActionResult Buy()
        {
            var order = _orderStorage.TryGetByUserId(Constants.UserId);
            _orderStorage.SaveOrderToXmlFile(order);
            _basketStorage.ClearBasket(Constants.UserId);
            return View();
        }
    }
}
