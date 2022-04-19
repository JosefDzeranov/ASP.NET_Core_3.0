using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Controllers
{
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

            orderManager.SaveOrder(new Order(cart, Constants.UserId));
            var order = orderManager.TryGetOrderById(Constants.UserId);

            return View(order);
        }

        public IActionResult MakeOrder()
        {
            var cart = cartManager.TryGetCartByUserID(Constants.UserId);
            cartManager.RemoveCartLines(cart);
            return View();
        }


    }
}