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

            if (basket == null || basket.Items.Count == 0)
            {
                return View("Empty");
            }

            return View(basket);
        }

        public IActionResult Add(int id)
        {
            var product = ProductStorage.TryGetProduct(id);
            BasketStorage.AddProduct(Constants.UserId, product);
            return RedirectToAction("Index");
        }

        public IActionResult Remove(int id)
        {
            var product = ProductStorage.TryGetProduct(id);
            BasketStorage.RemoveProduct(Constants.UserId, product);
            return RedirectToAction("Index");
        }

        public IActionResult Clear()
        {
            BasketStorage.ClearBasket(Constants.UserId);
            return RedirectToAction("Index");
        }
    }
}
