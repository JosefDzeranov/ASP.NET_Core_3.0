using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.DB;
using OnlineShop.DB.Models;
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
        private readonly UserManager<User> userManager;
        public FavoritesController(IProductRepository productRepository, IFavoriteRepository favoriteRepository, UserManager<User> userManager)
        {
            this.productRepository = productRepository;
            this.favoriteRepository = favoriteRepository;
            this.userManager = userManager;
        }

        public IActionResult Index()
        {
            var userId = userManager.FindByNameAsync(User.Identity.Name).Result.Id;
            var favorite = favoriteRepository.TryGetByUserId(userId);
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
            var userId = userManager.FindByNameAsync(User.Identity.Name).Result.Id;
            var product = productRepository.TryGetById(productId);
            favoriteRepository.Add(product, userId);

            return RedirectToAction(act, control, new{ id = productId });
        }

        public IActionResult Remove(Guid productId)
        {
            var userId = userManager.FindByNameAsync(User.Identity.Name).Result.Id;
            var product = productRepository.TryGetById(productId);
            favoriteRepository.Remove(product, userId);
            
            return RedirectToAction("Index");
        }
    }
}
