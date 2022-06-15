using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Services;
using OnlineShopWebApp.Models;
using OnlineShop.DB.Services;
using System;
using System.Collections.Generic;
using OnlineShop.DB;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using OnlineShop.DB.Models;
using System.Threading.Tasks;

namespace OnlineShopWebApp.Controllers
{
    [Authorize]
    public class CartController : Controller
    {
        private readonly IProductRepository productRepository;
        private readonly ICartRepository cartRepository;
        private readonly UserManager<User> userManager;

        public CartController(IProductRepository productRepository, ICartRepository cartRepository, UserManager<User> userManager)
        {
            this.productRepository = productRepository;
            this.cartRepository = cartRepository;
            this.userManager = userManager;

        }
        public IActionResult Index()
        {
            var userId = userManager.FindByNameAsync(User.Identity.Name).Result.Id;
            var cartDb = cartRepository.TryGetByUserId(userId);
            if(cartDb != null)
            {
                var cartViewModel = cartDb.MappingToCartViewModel();
                return View(cartViewModel);
            }
            return View();
        }

        public async Task<IActionResult> Add(Guid productId)
        {
            var userId = userManager.FindByNameAsync(User.Identity.Name).Result.Id;
            var product = await productRepository.TryGetByIdAsync(productId);
            cartRepository.Add(product, userId);

            return RedirectToAction("Index");
        }

        public IActionResult Remove(Guid productId)
        {
            var userId = userManager.FindByNameAsync(User.Identity.Name).Result.Id;
            cartRepository.RemoveItem(productId, userId);
            return RedirectToAction("Index");
        }
        public IActionResult RemoveAll()
        {
            var userId = userManager.FindByNameAsync(User.Identity.Name).Result.Id;
            cartRepository.Clear(userId);
            return RedirectToAction("Index");
        }
    }
}
