using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShopWebApp.Controllers
{
    public class FavoritesController : Controller
    {
        private readonly IProductManager productManager;
        private readonly IFavorites favoritesManager;

        List<Product> favoritesList = new List<Product>();

        public FavoritesController(IProductManager productManager, IFavorites favoritesManager)
        {
            this.productManager = productManager;
            this.favoritesManager = favoritesManager;
            
        }

        public IActionResult Index()
        {
            favoritesList = favoritesManager.Products;
            return View(favoritesList);

        }


        public IActionResult AddToFavorites(int id)
        {
            var foundProduct = productManager.FindProduct(id);


            if (favoritesManager.Products.FirstOrDefault(x => x.Id == id) == null)
            {
                favoritesManager.AddProduct(foundProduct);
                favoritesList = favoritesManager.Products;
                return View(favoritesList);
            }
            else
            {
                return RedirectToAction("Index");
            }

        }


    }

}