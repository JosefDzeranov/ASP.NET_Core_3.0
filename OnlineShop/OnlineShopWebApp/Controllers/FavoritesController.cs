using Microsoft.AspNetCore.Mvc;
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
            return View();
        }


        public IActionResult Add(int productId)
        {
            var product = productBase.TryGetById(productId);
            favorites.Add(product);

            return RedirectToAction("Index","Home");
        }
    }
}
