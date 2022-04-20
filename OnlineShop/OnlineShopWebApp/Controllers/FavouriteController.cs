﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShopWebApp.Controllers
{
    public class FavouriteController : Controller
    {
        private readonly IProductsRepository productsRepository;
        private readonly IFavouritesRepository favouritesRepository;

        public FavouriteController(IProductsRepository productsRepository, IFavouritesRepository favouritesRepository)
        {
            this.productsRepository = productsRepository;
            this.favouritesRepository = favouritesRepository;
        }
        public IActionResult Index()
        {
            var favouriteProducts = favouritesRepository.GetFavourites();
            return View(favouriteProducts);
        }

        public IActionResult Add(int productId)
        {
            var product = productsRepository.TryGetById(productId);
            favouritesRepository.Add(product);
            return RedirectToAction("Index");
        }

        public IActionResult ClearFavourites()
        {
            favouritesRepository.ClearFavourites();
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int productId)
        {
            var product = productsRepository.TryGetById(productId);
            favouritesRepository.Delete(product);
            return RedirectToAction("Index");
        }
    }
}
