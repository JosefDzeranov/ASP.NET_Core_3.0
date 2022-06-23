using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;

namespace OnlineShopWebApp.Controllers
{
    [Authorize]
    public class FavoriteController : Controller
    {
        private readonly IProductsStorage productStorage;
        private readonly IFavoriteStorage favoriteStorage;

        public FavoriteController(IProductsStorage productStorage, IFavoriteStorage favoriteStorage)
        {
            this.productStorage = productStorage;
            this.favoriteStorage = favoriteStorage;
        }
        public IActionResult Index()
        {
            var favoriteProducts = favoriteStorage.GetAllByUserId(Constants.UserId);
            if (favoriteProducts == null || favoriteProducts.Count == 0)
            {
                return View();
            }
            return View(favoriteProducts);
        }

        public IActionResult Add(Guid id)
        {
            var product = productStorage.TryGetProduct(id);
            favoriteStorage.Add(Constants.UserId, product);
            return RedirectToAction("Index");
        }

        public IActionResult Remove(Guid id)
        {
            var product = productStorage.TryGetProduct(id);
            favoriteStorage.Remove(Constants.UserId, product);
            return RedirectToAction("Index");
        }

        public IActionResult Clear()
        {
            favoriteStorage.Clear(Constants.UserId);
            return RedirectToAction("Index");
        }
    }
}