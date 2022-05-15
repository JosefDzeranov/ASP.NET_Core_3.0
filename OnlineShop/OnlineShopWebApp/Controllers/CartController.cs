using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Services;
using OnlineShopWebApp.Models;
using OnlineShop.DB.Services;
using System;
using System.Collections.Generic;

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
                var cartViewModel = new CartViewModel
                {
                    Id = cartDb.Id,
                    Items = new List<CartItemViewModel>(),
                    UserId = cartDb.UserId
                };
                foreach (var item in cartDb.Items)
                {
                    var itemViewModel = new CartItemViewModel
                    {
                        Id = item.Id,
                        Product = new ProductViewModel
                        {
                            Id = item.Product.Id,
                            Name = item.Product.Name,
                            Description = item.Product.Description,
                            Cost = item.Product.Cost,
                            ImgPath = item.Product.ImgPath

                        },
                        Quantinity = item.Quantinity,

                    };
                    cartViewModel.Items.Add(itemViewModel);
                }
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
