using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.DB;
using OnlineShop.DB.Services;
using OnlineShopWebApp.Models;
using OnlineShopWebApp.Services;
using System;
using System.Collections.Generic;

namespace OnlineShopWebApp.Controllers
{
    [Authorize]
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
            if(products != null)
            {
                var productsViewModel = new List<ProductViewModel>();

                foreach (var product in products)
                {
                    var productViewModel = product.MappingToProductViewModel();
                    productsViewModel.Add(productViewModel);
                }
                return View(productsViewModel);
            }

            return View();
        }


        public IActionResult Add(Guid productId, string control, string act)
        {
            var product = productRepository.TryGetById(productId);
            favoriteRepository.Add(product, Const.UserId);

            return RedirectToAction(act, control, new{ id = productId });
        }

        public IActionResult Remove(Guid productId)
        {
            var product = productRepository.TryGetById(productId);
            favoriteRepository.Remove(product, Const.UserId);
            
            return RedirectToAction("Index");
        }
    }
}
