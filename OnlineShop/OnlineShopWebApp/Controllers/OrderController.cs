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
            var makingOrder = new MakingOrder(cart);

            return View(makingOrder);
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