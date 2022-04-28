﻿using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Services;

namespace OnlineShopWebApp.Controllers
{
    public class FavouriteController : Controller
    {
        private readonly IProductsRepository productsRepository;
        private readonly IFavouriteRepository favouriteRepository;

        public FavouriteController(IProductsRepository productsRepository, IFavouriteRepository favouriteRepository)
        {
            this.productsRepository = productsRepository;
            this.favouriteRepository = favouriteRepository;
        }

        public IActionResult Index()
        {
            var favourite = favouriteRepository.TryGetByUserId(Constants.UserId);
            if (favourite == null || favourite.Products.Count == 0)
                return View("notFound");
            return View(favourite.Products);
        }

        public IActionResult Add(int productId)
        {
            var product = productsRepository.TryGetByid(productId);
            favouriteRepository.Add(product, Constants.UserId);

            return RedirectToAction("Index", "Favourite");
        }

        public IActionResult Clear(int productId)
        {
            var product = productsRepository.TryGetByid(productId);
            favouriteRepository.Clear(product, Constants.UserId);

            return RedirectToAction("Index", "Home");
        }
    }
}
