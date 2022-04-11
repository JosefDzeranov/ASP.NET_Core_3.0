using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace OnlineShopWebApp.Controllers
{
    public class BasketController : Controller
    {
        private DataStorage Data { get; }
        private BasketStorage Basket { get; }

        public BasketController (DataStorage dataStorage, BasketStorage basketStorage)
        {
            Data = dataStorage;
            Basket = basketStorage;
        }
        public IActionResult Index(int id)
        {
            var product = Data.TryGetProduct(id);           

            if (product == null)
            {           
                if(Basket.ProductBaskets.Count() == 0)
                {
                    return View("Empty");
                }
                return View(Basket);
            }

            Basket.AddProductBasket(product);
            return View(Basket);
        }
    }
}
