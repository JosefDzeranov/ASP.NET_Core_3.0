using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShopWebApp.Controllers
{
    public class FavouriteController : Controller
    {
        private readonly IProductsRepozitory productsRepozitory;
        private readonly IFavouritesRepozitory favouritesRepozitory;

        public FavouriteController(IProductsRepozitory productsRepozitory, IFavouritesRepozitory favouritesRepozitory)
        {
            this.productsRepozitory = productsRepozitory;
            this.favouritesRepozitory = favouritesRepozitory;
        }
        public IActionResult Index()
        {
            var favouriteProducts = favouritesRepozitory.GetFavourites();
            return View(favouriteProducts);
        }

        public IActionResult Add(int productId)
        {
            var product = productsRepozitory.TryGetById(productId);
            favouritesRepozitory.Add(product);
            return RedirectToAction("Index");
        }

        public IActionResult ClearFavourites()
        {
            favouritesRepozitory.ClearFavourites();
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int productId)
        {
            var product = productsRepozitory.TryGetById(productId);
            favouritesRepozitory.Delete(product);
            return RedirectToAction("Index");
        }
    }
}
