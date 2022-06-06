using OnlineShop.Db.Models;
using OnlineShopWebApp.Models;
using System.Collections.Generic;

namespace OnlineShopWebApp.Helper
{
    public static class Mapping
    {
        public static List<ProductViewModel> ToProductViewModels(List<Product> products)
        {
            var productViewModels = new List<ProductViewModel>();
            foreach (var product in products)
            {
                productViewModels.Add(ToProductViewModel(product));
            }
            return productViewModels;
        }
        public static ProductViewModel ToProductViewModel(Product product)
        {
            return new ProductViewModel
            {
                Id = product.Id,
                Name = product.Name,
                Cost = product.Cost,
                Description = product.Description,
                ImagePath = product.ImagePath
            };
        }
        public static CartViewModel ToCartViewModel(Cart cart)
        {
            if (cart==null)
            {
                return null;
            }
            return new CartViewModel
            {
                Id = cart.Id,
                UserId = cart.UserId,
                Items = ToCartItemViewModels(cart.Items)
            };
        }
        public static List<CartItemViewModel> ToCartItemViewModels(List<CartItem> cartItemsDb)
        {
            var cartItems = new List<CartItemViewModel>();
            foreach (var cartItemDb in cartItemsDb)
            {
                var cartItem = new CartItemViewModel
                {
                    Id = cartItemDb.Id,
                    Amount = cartItemDb.Amount,
                    Product = ToProductViewModel(cartItemDb.Product)
                };
                cartItems.Add(cartItem);
            }
            return cartItems;
        }
        public static OrderViewModel ToOrderViewModel(Order order)
        {
            OrderStatusViewModel status = (OrderStatusViewModel)(int)order.Status;
            return new OrderViewModel
            {
                Id = order.Id,
                CreatedDateTime = order.CreateDateTime,
                Status= status,
                User = order.User,
                Items= ToCartItemViewModels(order.Items)
            };
        }
        public static UserDeliveryInfoViewModel ToUserDeliveryInfoViewModel(UserDeliveryInfo user)
        {
            return new UserDeliveryInfoViewModel
            {
                FirstName = user.FirstName,
                SecondName = user.SecondName,
                Address = user.Address,
                Phone = user.Phone
            };
        }

        //public static User ToUser(UserDeliveryInfo user)
    }
}
