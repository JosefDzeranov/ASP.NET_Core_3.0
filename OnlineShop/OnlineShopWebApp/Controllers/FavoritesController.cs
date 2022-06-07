using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using OnlineShop.Db.Models;
using OnlineShopWebApp.Helpers;
using OnlineShopWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShopWebApp.Controllers
{
    public class FavoritesController : Controller
    {
        private readonly IProductManager productManager;
        private readonly IFavoritesManager favoritesManager;



        public FavoritesController(IProductManager productManager, IFavoritesManager favoritesManager)
        {
            this.productManager = productManager;
            this.favoritesManager = favoritesManager;

        }

        public IActionResult Index()
        {
            var favoritesList = favoritesManager.GetProducts(Constants.UserId);
            var favoritesListView = Mapping.ToProductsViewModels(favoritesList);
            return View(favoritesListView);

        }


        public IActionResult AddToFavorites(Guid id)
        {
           
            var foundProduct = productManager.TryGetById(id);
            favoritesManager.AddProduct(foundProduct, Constants.UserId);
            return RedirectToAction("Index");

        }

        public IActionResult Remove(Guid id)
        {
           
          
            favoritesManager.RemoveProduct(Constants.UserId, id);
            return RedirectToAction("Index");

        }


    }
}