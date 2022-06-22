using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;

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
            var userId = HttpContext.Request.Cookies["userId"];
            var favoriteProducts= _favoritesStorage.GetAllByUserId(userId);
            if (favoriteProducts == null || favoriteProducts.Count == 0)
            {
                return View("Empty");
            }
            return View(favoriteProducts);
        }

        public IActionResult Add(Guid id)
        {
            var userId = HttpContext.Request.Cookies["userId"];
            var product = _productStorage.TryGetProduct(id);
            _favoritesStorage.Add(userId, product);
            return RedirectToAction("Index");
        }

        public IActionResult Remove(Guid id)
        {
            var userId = HttpContext.Request.Cookies["userId"];
            var product = _productStorage.TryGetProduct(id);
            _favoritesStorage.Remove(userId, product);
            return RedirectToAction("Index");
        }

        public IActionResult Clear()
        {
            var userId = HttpContext.Request.Cookies["userId"];
            _favoritesStorage.Clear(userId);
            return RedirectToAction("Index");
        }
    }
}