using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Controllers
{
    public class CartController : Controller
    {


        Cart cart = CartManager.CreateCart();

        public IActionResult Index()
        {


            return View(cart);
        }


        public IActionResult AddToCart(int id)
        {
            var foundProduct = ProductManager.FindProduct(id);

            CartManager.AddProductToCart(Constants.UserId, foundProduct);
            return View("Index", cart);
        }



    }

}



