using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using OnlineShop.Db.Models;
using OnlineShopWebApp.Helpers;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        private readonly IOrderManager orderManager;
        private readonly ICartManager cartManager;


        public OrderController(IOrderManager orderManager, ICartManager cartManager)
        {
            this.orderManager = orderManager;
            this.cartManager = cartManager;
        }

        public IActionResult Index()
        {
            var cart = cartManager.TryGetCartByUserID(Constants.UserId);
            var orderData = new OrderDataViewModel
            {
                Cart = Mapping.ToCartViewModel(cart)
            };

            //var orderViewModel = new OrderViewModel
            //{
            //    Cart = Mapping.ToCartViewModel(cart)
            //};

            return View(orderData);
        }

        [HttpPost]
        public IActionResult MakeOrder(OrderDataViewModel orderData)
        {

            if (ModelState.IsValid)
            {
                var cart = cartManager.TryGetCartByUserID(Constants.UserId);
                var order = new Order(cart, Mapping.ToOrderData(orderData), Constants.UserId);


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