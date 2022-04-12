using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace OnlineShopWebApp.Controllers
{
    public class BasketController : Controller
    {
        private IProductStorage ProductStorage { get; }
        private IBasketStorage BasketStorage { get; }

        public BasketController (IProductStorage productStorage, IBasketStorage basketStorage)
        {
            ProductStorage = productStorage;
            BasketStorage = basketStorage;
        }
        public IActionResult Index(int id)
        {
            var product = ProductStorage.TryGetProduct(id);           

            if (product == null)
            {           
                if(BasketStorage.Baskets.Count() == 0)
                {
                    return View("Empty");
                }
                return View(BasketStorage);
            }

            BasketStorage.AddProduct(product);
            return View(BasketStorage);
        }
    }
}
