using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;

namespace OnlineShopWebApp.Controllers
{
    [Authorize]
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
            var favoriteProducts= _favoritesStorage.GetAllByUserId(Constants.UserId);
            if (favoriteProducts == null || favoriteProducts.Count == 0)
            {
                return View("Empty");
            }
            return View(favoriteProducts);
        }

        public IActionResult Add(Guid id)
        {
            var product = _productStorage.TryGetProduct(id);
            _favoritesStorage.Add(Constants.UserId, product);
            return RedirectToAction("Index");
        }

        public IActionResult Remove(Guid id)
        {
            var product = _productStorage.TryGetProduct(id);
            _favoritesStorage.Remove(Constants.UserId, product);
            return RedirectToAction("Index");
        }

        public IActionResult Clear()
        {
            _favoritesStorage.Clear(Constants.UserId);
            return RedirectToAction("Index");
        }
    }
}