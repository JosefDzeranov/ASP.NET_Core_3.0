using OnlineShop.Db.Models;
using OnlineShopWebApp.Models;
using System.Collections.Generic;

namespace OnlineShopWebApp.Helpers
{
    public static class Mapping
    {
        public static ProductViewModel ToProductViewModel(this Product product)
        {
            var productViewModel = new ProductViewModel

            {
                Id = product.Id,

                ImagePath = product.ImagePath,

                Name = product.Name,

                Cost = product.Cost,

                Description = product.Description
            };

            return productViewModel;
        }

        public static List<ProductViewModel> ToProductViewModels(this List<Product> products)
        {
            var productViewModels = new List<ProductViewModel>();

            foreach (var product in products)
            {
                var productViewModel = product.ToProductViewModel();

                productViewModels.Add(productViewModel);
            }

            return productViewModels;
        }

        public static Product ToProduct(this ProductViewModel productViewModel)
        {
            var product = new Product

            {
                Id = productViewModel.Id,

                ImagePath = productViewModel.ImagePath,

                Name = productViewModel.Name,

                Cost = productViewModel.Cost,

                Description = productViewModel.Description
            };

            return product;
        }

        public static CartItemViewModel ToCartItemViewModel(this CartItem cartItem)
        {
            var CartItemViewModel = new CartItemViewModel

            {
                ItemId = cartItem.ItemId,

                Product = cartItem.Product,

                Count = cartItem.Count
            };

            return CartItemViewModel;
        }

        public static CartViewModel ToCartViewModel(this Cart cart)
        {
            if (cart == null)
            {
                return null;
            }

            var items = new List<CartItemViewModel>();

            foreach (var item in cart.Items)
            {
                items.Add(item.ToCartItemViewModel());
            }

            var cartViewModel = new CartViewModel
            {
                Id = cart.Id,
                UserId = cart.UserId,
                Items = items
            };

            return cartViewModel;
        }

        public static List<CartItemViewModel> ToCartItemViewModels(this List<CartItem> items)
        {
            var cartItemViewModels = new List<CartItemViewModel>();

            foreach (var item in items)
            {
                var cartItemViewModel = item.ToCartItemViewModel();
                cartItemViewModels.Add(cartItemViewModel);
            }

            return cartItemViewModels;
        }
    }
}