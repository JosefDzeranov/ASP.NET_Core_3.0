using OnlineShop.Db.Models;
using OnlineShopWebApp.Models;
using System.Collections.Generic;

namespace OnlineShopWebApp.Helpers
{
    public static class Mapping
    {
        public static List<ProductViewModel> ToProductsViewModels(List<Product> products)
        {
            var productsViewModels = new List<ProductViewModel>();
            foreach (var product in products)
            {

                productsViewModels.Add(ToProductViewModel(product));
            }
            return productsViewModels;
        }

        public static ProductViewModel ToProductViewModel(Product product)
        {
            return new ProductViewModel
            {
                Id = product.Id,
                Name = product.Name,
                Cost = product.Cost,
                Description = product.Description

            };

        }

        public static CartViewModel ToCartViewModel(Cart cart)
        {
            if (cart == null)
            {
                return null;
            }
            return new CartViewModel
            {
                Id = cart.Id,
                CartLines = ToCartLinesViewModels(cart.CartLines),
                UserId = cart.UserId

            };

        }

        public static List<CartLineViewModel> ToCartLinesViewModels(List<CartLine> cartLinesDB)
        {
            var cartLineViewModels = new List<CartLineViewModel>();

            foreach (var cartLineDB in cartLinesDB)
            {
                var cartLineViewModel = new CartLineViewModel
                {
                    Id = cartLineDB.Id,
                    Product = Mapping.ToProductViewModel(cartLineDB.Product),
                    Amount = cartLineDB.Amount,


                };
                cartLineViewModels.Add(cartLineViewModel);
            }
            return cartLineViewModels;
        }
    }
}
