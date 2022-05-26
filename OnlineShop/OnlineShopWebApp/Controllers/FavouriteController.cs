using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using OnlineShopWebApp.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShopWebApp.Controllers
{
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
            return View(favouritesRepository.GetAll(Constants.UserId));
        }

        public IActionResult Add(Guid productId)
        {
            //var product = productsRepository.TryGetById(productId);
            favouritesRepository.Add(Constants.UserId, productId);
            return RedirectToAction("Index");
        }

        //public IActionResult Clear()
        //{
        //    favouritesRepository.Clear();
        //    return RedirectToAction("Index");
        //}
        //public IActionResult Delete(Guid productId)
        //{
        //    var product = productsRepository.TryGetById(productId);
        //    favouritesRepository.Delete(Mapping.ToProductViewModel(product));
        //    return RedirectToAction("Index");
        //}
    }
}
