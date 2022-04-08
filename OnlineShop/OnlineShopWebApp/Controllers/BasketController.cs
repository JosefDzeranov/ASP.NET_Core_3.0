using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace OnlineShopWebApp.Controllers
{
    public class BasketController : Controller
    {
        public IActionResult Index(int id)
        {
            var basket = new DataStorage();
            var product = basket.TryGetProduct(id);           

            if (product == null)
            {           
                if(basket.Products.Count() == 0)
                {
                    return View("Empty");
                }
                return View(basket);
            }

            basket.AddToBasket(product, 1);
            return View(basket);
        }
    }
}
