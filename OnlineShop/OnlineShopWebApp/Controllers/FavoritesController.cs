using Microsoft.AspNetCore.Mvc;

namespace OnlineShopWebApp.Controllers
{
    public class FavoritesController : Controller
    {
        private readonly IProductStorage _productStorage;
        private readonly IFavoritesStorage _favoritesStorage;

        public FavoritesController(IProductStorage productStorage, IFavoritesStorage favoritesStorage)
        {
            _productStorage = productStorage;
            _favoritesStorage = favoritesStorage;
        }
        public IActionResult Index()
        {
            var favoritesBasket = _favoritesStorage.TryGetByUserId(Constants.UserId);
            if (favoritesBasket == null || favoritesBasket.Items.Count == 0)
            {
                return View("Empty");
            }
            return View(favoritesBasket);
        }

        public IActionResult Add(int id)
        {
            var product = _productStorage.TryGetProduct(id);
            _favoritesStorage.AddProduct(Constants.UserId, product);
            return RedirectToAction("Index");
        }

        public IActionResult Remove(int id)
        {
            var product = _productStorage.TryGetProduct(id);
            _favoritesStorage.RemoveProduct(Constants.UserId, product);
            return RedirectToAction("Index");
        }

        public IActionResult Clear()
        {
            _favoritesStorage.ClearBasket(Constants.UserId);
            return RedirectToAction("Index");
        }
    }
}