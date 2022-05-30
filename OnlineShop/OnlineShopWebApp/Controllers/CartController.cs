using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Services;
using OnlineShopWebApp.Models;
using OnlineShop.DB.Services;
using System;
using System.Collections.Generic;
using OnlineShop.DB;

namespace OnlineShopWebApp.Controllers
{
    public class CartController : Controller
    {
        private readonly IProductRepository productRepository;
        private readonly ICartRepository cartRepository;

        public CartController(IProductRepository productRepository, ICartRepository cartRepository)
        {
            this.productRepository = productRepository;
            this.cartRepository = cartRepository;

        }
        public IActionResult Index()
        {
            var cartDb = cartRepository.TryGetByUserId(Const.UserId);
            if(cartDb != null)
            {
                var cartViewModel = cartDb.MappingCartViewModel();
                return View(cartViewModel);
            }
            return View();
        }

        public IActionResult Add(Guid productId)
        {

            var product = productRepository.TryGetById(productId);
            cartRepository.Add(product, Const.UserId);

            return RedirectToAction("Index");
        }

        public IActionResult Remove(Guid productId)
        {
            cartRepository.RemoveItem(productId, Const.UserId);
            return RedirectToAction("Index");
        }
        public IActionResult RemoveAll()
        {
            cartRepository.Clear(Const.UserId);
            return RedirectToAction("Index");
        }
    }
}
