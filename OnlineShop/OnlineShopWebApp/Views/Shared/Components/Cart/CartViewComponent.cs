using Microsoft.AspNetCore.Mvc;
using OnlineShop.DB.Services;
using OnlineShopWebApp.Models;
using OnlineShopWebApp.Services;
using System.Collections.Generic;

namespace OnlineShopWebApp.Views.Shared.Components.Cart
{
    public class CartViewComponent : ViewComponent
    {
        private readonly ICartRepository cartRepository;

        public CartViewComponent(ICartRepository cartRepository)
        {
            this.cartRepository = cartRepository;
        }

        public IViewComponentResult Invoke()
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
                var productCount = cartViewModel?.Count ?? 0;
                return View("Cart", productCount);
            }

            return View("Cart", 0);
        }
    }
}
