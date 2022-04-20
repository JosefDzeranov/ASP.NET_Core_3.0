using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Controllers
{
    public class CartController : Controller
    {
        private ICartManager cartManager;
        private readonly IProductManager productManager;

        public CartController(ICartManager cartManager, IProductManager productManager)
        {
            this.cartManager = cartManager;
            this.productManager = productManager;
        }

        public IActionResult Index()
        {
            var cart = cartManager.CreateCart();

            return View(cart);
        }


        public IActionResult AddToCart(int id)
        {
            var foundProduct = productManager.FindProduct(id);


            cartManager.AddProductToCart(Constants.UserId, foundProduct);
           
            return RedirectToAction("Index");
        }

        public IActionResult RemoveFromCart(int id)
        {
            var foundProduct = productManager.FindProduct(id);
            cartManager.RemoveProductFromCart(Constants.UserId, foundProduct.Id);
         
            return RedirectToAction("Index");

        }

        public IActionResult ClearCart()
        {
            var cart = cartManager.TryGetCartByUserID(Constants.UserId);
            cartManager.RemoveCartLines(cart);
            return RedirectToAction("Index");

        }

    }

}
