using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using OnlineShopWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShopWebApp.Controllers
{
    public class FavoritesController : Controller
    {
        private readonly IProductManager productManager;
        private readonly IFavorites favoritesManager;



        public FavoritesController(IProductManager productManager, IFavorites favoritesManager)
        {
            this.productManager = productManager;
            this.favoritesManager = favoritesManager;

        }

        public IActionResult Index()
        {
            var favoritesList = favoritesManager.Products;
            return View(favoritesList);

        }


        public IActionResult AddToFavorites(Guid id)
        {
            var foundProduct = productManager.TryGetById(id);

            var productView = new ProductViewModel
            {
                Name = foundProduct.Name,
                Cost = foundProduct.Cost,
                Description = foundProduct.Description,

            };


            if (favoritesManager.Products.FirstOrDefault(x => x.Id == id) == null)
            {
                favoritesManager.AddProduct(productView);
                var favoritesList = favoritesManager.Products;
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index");
            }

        }

    }
}