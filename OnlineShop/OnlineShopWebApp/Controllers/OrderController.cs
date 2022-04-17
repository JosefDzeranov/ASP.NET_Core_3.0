using Microsoft.AspNetCore.Mvc;

namespace OnlineShopWebApp.Controllers
{
    public class OrderController : Controller
    {
        private IOrderStorage OrderStorage { get; }
        private IBasketStorage BasketStorage { get; }
        private IDeliveryStorage DeliveryStorage { get; }

        public OrderController(IOrderStorage orderStorage, IBasketStorage basketStorage, IDeliveryStorage deliveryStorage)
        {
            OrderStorage = orderStorage;
            BasketStorage = basketStorage;
            DeliveryStorage = deliveryStorage;
        }
        public IActionResult Index()
        {
            var order = OrderStorage.TryGetByUserId(Constants.UserId);
            return View(order);
        }

        public IActionResult Add()
        {
            var basket = BasketStorage.TryGetByUserId(Constants.UserId);
            var delivery = DeliveryStorage.GetDeliveryData();
            OrderStorage.AddOrder(Constants.UserId, basket, delivery);
            return RedirectToAction("Index");
        }
        public IActionResult Buy()
        {
            var order = OrderStorage.TryGetByUserId(Constants.UserId);
            OrderStorage.SaveOrderToXmlFile(order);
            BasketStorage.ClearBasket(Constants.UserId);
            return View();
        }
    }
}
