using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Controllers
{
    public class CartController : Controller
    {
        public IActionResult Index()
        {
            return View(Cart.addedProducts);
        }

        public IActionResult AddToCart(int id)
        {
            var foundProduct = ProductManager.FindProduct(id);
            foundProduct.Number++;
            Cart.AddProductToCart(foundProduct);

            return View("Index", Cart.addedProducts);
        }

    }

   
}
