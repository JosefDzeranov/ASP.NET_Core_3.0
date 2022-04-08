using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace OnlineShopWebApp.Controllers
{
    public class BasketController : Controller
    {
        private static BasketContent Basket { get; set; }

        public BasketController()
        {
            Basket = new BasketContent();
        }
        public IActionResult Index(int id)
        {
            var product = new DataStorage().GetProduct(id);

            if (product == null)
            {           
                if(Basket.Products.Count() == 0)
                {
                    return View("Empty");
                }
                return View(Basket);
            }

            Basket.AddToBasket(product, 1);
            return View(Basket);
        }
    }
}
