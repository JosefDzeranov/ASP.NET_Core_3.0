using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace OnlineShopWebApp.Controllers
{
    public class BasketController : Controller
    {
        private ProductStorage ProductStorage { get; }
        private BasketStorage Basket { get; }

        public BasketController (ProductStorage productStorage, BasketStorage basketStorage)
        {
            ProductStorage = productStorage;
            Basket = basketStorage;
        }
        public IActionResult Index(int id)
        {
            var product = ProductStorage.TryGetProduct(id);           

            if (product == null)
            {           
                if(Basket.Baskets.Count() == 0)
                {
                    return View("Empty");
                }
                return View(Basket);
            }

            Basket.AddProduct(product);
            return View(Basket);
        }
    }
}
