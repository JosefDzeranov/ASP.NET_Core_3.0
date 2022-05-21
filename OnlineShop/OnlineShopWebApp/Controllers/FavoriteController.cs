using Microsoft.AspNetCore.Mvc;
using OnlineShop.db;
using OnlineShopWebApp.Helpers;
using System;
using OnlineShop.Db;

namespace OnlineShopWebApp.Controllers
{
    public class FavoriteController : Controller
    {
        private readonly IFavoriteRepository favoriteRepository;
        private readonly IProductDataSource productDataSource;

        public FavoriteController(IFavoriteRepository favoriteRepository, IProductDataSource productDataSource)
        {
            this.favoriteRepository = favoriteRepository;
            this.productDataSource = productDataSource;
        }
        public IActionResult Index()
        {
            var products = favoriteRepository.GetAll(Const.UserId);
            return View(Mapping.ToProductViewModels(products));
        }

        public IActionResult Add(int productId)
        {
            var product = productDataSource.GetProductById(productId);
            favoriteRepository.Add(Const.UserId, product);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Remove (int productId)
        {
            favoriteRepository.Remove(Const.UserId, productId);
            return RedirectToAction(nameof(Index));
        }
    }
}
