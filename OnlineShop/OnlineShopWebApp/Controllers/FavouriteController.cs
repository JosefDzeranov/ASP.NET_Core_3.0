using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Services;

namespace OnlineShopWebApp.Controllers
{
    public class FavouriteController : Controller
    {
        private readonly IProductsRepository productsRepository;
        private readonly IFavouriteRepository favouriteRepository;

        public FavouriteController(IProductsRepository productsRepository, IFavouriteRepository favouriteRepository)
        {
            this.productsRepository = productsRepository;
            this.favouriteRepository = favouriteRepository;
        }

        public IActionResult Index()
        {
            var favourite = favouriteRepository.TryGetByUserId(Constants.UserId);
            return View();
        }

        public IActionResult Add(int productId)
        {
            var product = productsRepository.TryGetByid(productId);
            favouriteRepository.Add(product, Constants.UserId);

            return RedirectToAction("Home");
        }

        public IActionResult Clear(int productId)
        {
            var product = productsRepository.TryGetByid(productId);
            favouriteRepository.Clear(product, Constants.UserId);

            return RedirectToAction("Home");
        }
    }
}
