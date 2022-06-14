using OnlineShop.Db.Models;
using OnlineShopWebApp.Admin.Models;
using OnlineShopWebApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShopWebApp.Helper
{
    public static class Mapping
    {
        public static List<ProductViewModel> ToProductViewModels(this List<Product> products)
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
                ImagesPaths = product.Images.Select(x => x.Url).ToArray()
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

        public static Product ToProduct(this AddProductViewModel addProductViewModel, List<string> imagesPaths)
        {
            return new Product
            {
                Name = addProductViewModel.Name,
                Cost = addProductViewModel.Cost,
                Description = addProductViewModel.Description,
                Images = ToImages(imagesPaths)
            };
        }

        public static List<Image> ToImages(this List<string> paths)
        {
            return paths.Select(x => new Image { Url = x }).ToList();
        }
        
    }
}
