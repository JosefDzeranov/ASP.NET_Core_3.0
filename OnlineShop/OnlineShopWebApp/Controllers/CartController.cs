using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Models;
using System.Linq;


namespace OnlineShopWebApp.Controllers
{
    public class CartController : Controller
    {
        private static CartStorage Cart 
        { 
            get; set; 
        }

        public CartController()
        {
            Cart = new CartStorage();
        }

        public IActionResult Index(int id)
        {
            var product = new DataStorage();
            var r = product.GetProductId(id).Where(p => p.Id == id).FirstOrDefault();

            if (product == null)
            {
                if (Cart.Products.Count() == 0)
                {
                    return View("Empty");
                }
                return View(Cart);
            }

            Cart.AddToCart(product, 1);

            return View(Cart);
        }
    }
}
