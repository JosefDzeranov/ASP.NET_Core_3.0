using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
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
            var userId = Constants.UserId;
            var foundProduct = productManager.TryGetById(id);

            //var productView = new ProductViewModel
            //{
            //    Name = foundProduct.Name,
            //    Cost = foundProduct.Cost,
            //    Description = foundProduct.Description,

            //};


            if (favoritesManager.GetProducts(userId).FirstOrDefault(x => x.Id == id) == null)
            {
                favoritesManager.AddProduct(foundProduct,userId);
                //var favoritesList = favoritesManager.Products;
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index");
            }

        }

    }
}