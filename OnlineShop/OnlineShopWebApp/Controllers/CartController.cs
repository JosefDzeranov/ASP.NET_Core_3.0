using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Controllers
{
    public class CartController : Controller
    {
        private CartManager cartManager;
        
       

        public IActionResult Index()
        {
            var cart = cartManager.CreateCart();

            return View(cart);
        }


        public IActionResult AddToCart(int id)
        {
            var foundProduct = ProductManager.FindProduct(id);
            

            cartManager.AddProductToCart(IdStorage.UserId, foundProduct);
            var cart = cartManager.TryGetCartByUserID(IdStorage.UserId);
            return View("Index", cart);
        }

        public CartController(CartManager cartManager)
        {
            this.cartManager = cartManager;
           
        }

    }

    

}



