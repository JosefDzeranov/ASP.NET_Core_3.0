using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Services;

namespace OnlineShopWebApp.Controllers
{
    public class FavoriteController : Controller
    {
        private readonly IProductRepository productRepository;
        private readonly IFavoriteRepository favoriteRepository;

        public FavoriteController(IProductRepository productRepository, IFavoriteRepository favoriteRepository)
        {
            this.productRepository = productRepository;
            this.favoriteRepository = favoriteRepository;
        }

        public IActionResult Index()
        {
            var favorite = favoriteRepository.TryGetByUserId(Const.UserId);
            return View(favorite.Products);
        }


        public IActionResult Add(int productId)
        {
            var product = productRepository.TryGetById(productId);
            favoriteRepository.Add(product, Const.UserId);

            return RedirectToAction("Index", "Home");
        }

        public IActionResult Remove(int productId)
        {
            var product = productRepository.TryGetById(productId);
            favoriteRepository.Remove(product, Const.UserId);
            
            return RedirectToAction("Index");
        }
    }
}
