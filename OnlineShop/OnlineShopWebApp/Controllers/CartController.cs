using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Controllers
{
    public class CartController : Controller
    {
        private CartManager cartManager;
       // private Cart cart;
       

        public IActionResult Index()
        {


            return View(cartManager.cart);
        }


        public IActionResult AddToCart(int id)
        {
            var foundProduct = ProductManager.FindProduct(id);

            cartManager.AddProductToCart(IdStorage.UserId, foundProduct);
            return View("Index", cartManager.cart);
        }

        public CartController(CartManager cartManager)
        {
            this.cartManager = cartManager;
           
        }

    }

    

}



