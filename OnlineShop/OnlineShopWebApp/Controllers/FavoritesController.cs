using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Services;

namespace OnlineShopWebApp.Controllers
{
    public class FavoritesController : Controller
    {
        private readonly IProductRepository productRepository;
        private readonly IFavoriteRepository favoriteRepository;

        public FavoritesController(IProductRepository productRepository, IFavoriteRepository favoriteRepository)
        {
            this.productRepository = productRepository;
            this.favoriteRepository = favoriteRepository;
        }

        public IActionResult Index()
        {
            var favorite = favoriteRepository.TryGetByUserId(Const.UserId);
            var products = favorite?.Products;
            return View(products);
        }


        public IActionResult Add(int productId, string control, string act)
        {
            var product = productRepository.TryGetById(productId);
            favoriteRepository.Add(product, Const.UserId);

            return RedirectToAction(act, control);
        }

        public IActionResult Remove(int productId)
        {
            var product = productRepository.TryGetById(productId);
            favoriteRepository.Remove(product, Const.UserId);
            
            return RedirectToAction("Index");
        }
    }
}
