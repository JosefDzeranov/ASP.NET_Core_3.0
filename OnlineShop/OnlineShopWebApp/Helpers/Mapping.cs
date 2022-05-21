using System.Collections.Generic;
using OnlineShopWebApp.Models;
using OnlineShop.db.Models;
using System.Linq;

namespace OnlineShopWebApp.Helpers
{
    public static class Mapping
    {
        public static IEnumerable<ProductViewModel> ToProductViewModels(IEnumerable<Product> products)
        {
            foreach (var product in products)
            {
                yield return ToProductViewModel(product);
            }
        }
        public static ProductViewModel ToProductViewModel(Product product)
        {
            return new ProductViewModel

            {
                Id = product.Id,
                Name = product.Name,
                Cost = product.Cost,
                Description = product.Description,
                ImagePath = product.ImagePath,
            };
        }

        public static CartViewModel ToCartViewModel(Cart cart)
        {
            return new CartViewModel
            {
                Id = cart.Id,
                UserId = cart.UserId,
                Items = ToCartItemsViewModels(cart.Items).ToList(),
            };
        }
        public static IEnumerable<CartItemViewModel> ToCartItemsViewModels(IEnumerable<CartItem> cartDbItems)
        {
            //var cartItems = new List<CartItemViewModel>();
            foreach (var cartDbItem in cartDbItems)
            {
                yield return new CartItemViewModel
                {
                    Id = cartDbItem.Id,
                    Amount = cartDbItem.Amount,
                    Product = ToProductViewModel(cartDbItem.Product)
                };
                //cartItems.Add(cartItem);
            }
            //return cartItems;
        }
    }
}
