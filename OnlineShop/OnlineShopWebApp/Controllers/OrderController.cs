using Microsoft.AspNetCore.Mvc;
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
                Cart = cart
            };

            return View(orderData);
        }
       
        [HttpPost]
        public IActionResult MakeOrder(OrderData orderData)
        {

            if (ModelState.IsValid)
            {
                var cart = cartManager.TryGetCartByUserID(Constants.UserId);
                var order = new Order(cart, orderData, Constants.UserId);
              

                orderManager.SaveOrder(order);
                cartManager.Clear(Constants.UserId);
                return View();
            }
            else
            {
                return RedirectToAction("Index");
            }
            

           
        }

    }
}