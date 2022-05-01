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
            var order = new Order(cart);

            return View(order);
        }
       
        [HttpPost]
        public IActionResult MakeOrder(Order order)
        {

            if (ModelState.IsValid)
            {
                var cart = cartManager.TryGetCartByUserID(Constants.UserId);

                order.Cart = cart;
                order.UserId = Constants.UserId;

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