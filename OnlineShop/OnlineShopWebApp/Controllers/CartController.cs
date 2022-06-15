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
        public async Task<IActionResult> Index()
        {
            var userId = (await userManager.FindByNameAsync(User.Identity.Name)).Id;
            var cartDb = await cartRepository.TryGetByUserIdAsync(userId);
            if (cartDb != null)
            {
                var cartViewModel = cartDb.MappingToCartViewModel();
                return View(cartViewModel);
            }
            return View();
        }

        public async Task<IActionResult> AddAsync(Guid productId)
        {
            var userId = (await userManager.FindByNameAsync(User.Identity.Name)).Id;
            var product = await productRepository.TryGetByIdAsync(productId);
            await cartRepository.AddAsync(product, userId);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> RemoveAsync(Guid productId)
        {
            var userId = (await userManager.FindByNameAsync(User.Identity.Name)).Id;
            await cartRepository.RemoveItemAsync(productId, userId);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> RemoveAllAsync()
        {
            var userId = (await userManager.FindByNameAsync(User.Identity.Name)).Id;
            await cartRepository.ClearAsync(userId);
            return RedirectToAction("Index");
        }
    }
}
