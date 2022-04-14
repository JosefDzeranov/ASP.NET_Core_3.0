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
        public IActionResult Index()
        {
            var basket = BasketStorage.TryGetByUserId(Constants.UserId);

            if (basket == null)
            {
                return View("Empty");
            }

            return View(basket);
        }

        public IActionResult Add(int id)
        {
            var product = ProductStorage.TryGetProduct(id);
            BasketStorage.AddProduct(product, Constants.UserId);
            return RedirectToAction("Index");
        }

        public IActionResult Remove(int id)
        {
            var product = ProductStorage.TryGetProduct(id);
            BasketStorage.RemoveProduct(product, Constants.UserId);
            return RedirectToAction("Index");
        }

        public IActionResult Clear()
        {
            BasketStorage.ClearBasket(Constants.UserId);
            return RedirectToAction("Index");
        }
    }
}
