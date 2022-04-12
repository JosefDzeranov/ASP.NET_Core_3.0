using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Interface;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrdersStorage ordersStorage;

        private readonly ICartsStorage cartsStorage;

        private readonly Constants constants;

        public OrderController(ICartsStorage cartsStorage, IOrdersStorage ordersStorage)
        {
            this.cartsStorage = cartsStorage;

            this.ordersStorage = ordersStorage;
;
            constants = new Constants();
        }
        
        public IActionResult Index()
        {
            var order = ordersStorage.TryGetOrderByUserId(constants.UserId);

            return View(order);
        }

        public IActionResult Add(string userId)
        {
            //var order = ordersStorage.TryGetProduct(productId);

            ordersStorage.Add(userId);

            return RedirectToAction("Index");
        }

        public ActionResult Edit(string userId)
        {
            var order = ordersStorage.TryGetOrderByUserId(userId);
            if (userId == null)
            {
                return RedirectToAction("Index");
            }
            else
                return View(order);
        }

    }
}
