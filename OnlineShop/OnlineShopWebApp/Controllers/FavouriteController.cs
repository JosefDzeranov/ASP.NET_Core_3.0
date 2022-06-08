using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using OnlineShopWebApp.Helpers;
using System;

namespace OnlineShopWebApp.Controllers
{
    [Authorize]
    public class FavouriteController : Controller
    {
        private readonly IProductsRepository productsRepository;
        private readonly IFavouritesRepository favouritesRepository;

        public FavouriteController(IProductsRepository productsRepository, IFavouritesRepository favouritesRepository)
        {
            this.productsRepository = productsRepository;
            this.favouritesRepository = favouritesRepository;
        }
        public IActionResult Index()
        {
            var products = favouritesRepository.GetFavourites(Constants.UserId);
            return View(Mapping.ToProductViewModels(products));
        }

        public IActionResult Add(Guid productId)
        {
            var product = productsRepository.TryGetById(productId);
            favouritesRepository.Add(Constants.UserId, product);
            return RedirectToAction("Index");
        }

        public IActionResult Clear()
        {
            favouritesRepository.Clear(Constants.UserId);
            return RedirectToAction("Index");
        }
        public IActionResult Delete(Guid productId)
        {            
            favouritesRepository.Delete(Constants.UserId, productId);
            return RedirectToAction("Index");
        }
    }
}
