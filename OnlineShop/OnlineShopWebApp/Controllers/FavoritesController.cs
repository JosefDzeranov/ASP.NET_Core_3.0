﻿using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Services;

namespace OnlineShopWebApp.Controllers
{
    public class FavoritesController : Controller
    {
        private readonly IProductBase productBase;
        private readonly IFavorites favorites;

        public FavoritesController(IProductBase productBase, IFavorites favorites)
        {
            this.productBase = productBase;
            this.favorites = favorites;
        }

        public IActionResult Index()
        {
            var favorite = favorites.TryGetByUserId(Const.UserId);
            return View(favorite.Products);
        }


        public IActionResult Add(int productId)
        {
            var product = productBase.TryGetById(productId);
            favorites.Add(product, Const.UserId);

            return RedirectToAction("Index", "Home");
        }

        public IActionResult Remove(int productId)
        {
            var product = productBase.TryGetById(productId);
            favorites.Remove(product, Const.UserId);

            return RedirectToAction("Index");
        }
    }
}
