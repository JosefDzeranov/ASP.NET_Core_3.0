using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Controllers
{
    public class CartController : Controller
    {
        private CartManager cartManager;
        private readonly ProductManager productManager;

        public CartController(CartManager cartManager, ProductManager productManager)
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
            var cart = cartManager.TryGetCartByUserID(Constants.UserId);
            return View("Index", cart);
        }



    }



}



