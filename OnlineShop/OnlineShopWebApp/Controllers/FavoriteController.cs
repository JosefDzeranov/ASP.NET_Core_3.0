using Microsoft.AspNetCore.Mvc;
using OnlineShop.db;
using OnlineShopWebApp.Helpers;
using Microsoft.AspNetCore.Authorization;

namespace OnlineShopWebApp.Controllers
{
    [Authorize]
    public class FavoriteController : Controller
    {
        private readonly IFavoriteRepository favoriteRepository;
        private readonly IProductDataSource productDataSource;

        public FavoriteController(IFavoriteRepository favoriteRepository, IProductDataSource productDataSource)
        {
            this.favoriteRepository = favoriteRepository;
            this.productDataSource = productDataSource;
        }
        public IActionResult Index()
        {
            var products = favoriteRepository.GetAll(User.Identity.Name);
            return View(Mapping.ToProductViewModels(products));
        }

        public IActionResult Add(int productId)
        {
            var product = productDataSource.GetProductById(productId);
            favoriteRepository.Add(User.Identity.Name, product);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Remove(int productId)
        {
            favoriteRepository.Remove(User.Identity.Name, productId);
            return RedirectToAction(nameof(Index));
        }
    }
}
