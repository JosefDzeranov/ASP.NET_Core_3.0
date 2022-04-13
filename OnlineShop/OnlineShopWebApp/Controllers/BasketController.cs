using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace OnlineShopWebApp.Controllers
{
    public class BasketController : Controller
    {
        private IProductStorage ProductStorage { get; }
        private IBasketStorage BasketStorage { get; }

        public BasketController(IProductStorage productStorage, IBasketStorage basketStorage)
        {
            ProductStorage = productStorage;
            BasketStorage = basketStorage;
        }
        public IActionResult Index(int id)
        {
            if (BasketStorage.Baskets.Count() == 0)
            {
                return View("Empty");
            }

            return View(BasketStorage);
        }

        public IActionResult Add(int id)
        {
            var product = ProductStorage.TryGetProduct(id);
            BasketStorage.AddProduct(product);
            return RedirectToAction("Index");
        }

        public IActionResult Remove(int id)
        {
            var product = ProductStorage.TryGetProduct(id);
            BasketStorage.RemoveProduct(product);
            return RedirectToAction("Index");
        }

        public IActionResult Clear()
        {
            BasketStorage.ClearBasket();
            return RedirectToAction("Index");
        }
    }
}
