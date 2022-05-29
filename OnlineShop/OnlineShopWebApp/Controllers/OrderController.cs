using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using OnlineShopWebApp.Helpers;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Controllers
{
    public class OrderController : Controller
    {
        IOrderManager orderManager;
        private readonly ICartManager cartManager;


        public OrderController(IOrderManager orderManager, ICartManager cartManager)
        {
            this.orderManager = orderManager;
            this.cartManager = cartManager;
        }

        public IActionResult Index()
        {
            var cart = cartManager.TryGetCartByUserID(Constants.UserId);
            var orderData = new OrderData
            {
                Cart = Mapping.ToCartViewModel(cart)
            };

            return View(orderData);
        }

        [HttpPost]
        public IActionResult MakeOrder(OrderData orderData)
        {

            if (ModelState.IsValid)
            {
                var cart = cartManager.TryGetCartByUserID(Constants.UserId);
                var order = new Order(Mapping.ToCartViewModel(cart), orderData, Constants.UserId);


                orderManager.SaveOrder(order);
                cartManager.RemoveCartLines(cart);
                return View();
            }
            else
            {
                return RedirectToAction("Index");
            }



        }

    }
}