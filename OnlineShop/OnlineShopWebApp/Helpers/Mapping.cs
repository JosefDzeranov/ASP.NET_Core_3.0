using System.Collections.Generic;
using OnlineShopWebApp.Models;
using OnlineShop.db.Models;
using System.Linq;
using OnlineShop.db;
using OnlineShopWebApp.Areas.Admin.Models;

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
        public static ProductViewModel ToProductViewModel(this Product product)
        {
            return new ProductViewModel
            {
                Id = product.Id,
                Name = product.Name,
                Cost = product.Cost,
                Description = product.Description,
                ImagesPath = product.Images?.Select(x => x.Url).ToArray()
            };
        }
        public static CartViewModel ToCartViewModel(Cart cart)
        {
            if (cart != null)
            {
                return new CartViewModel
                {
                    Id = cart.Id,
                    UserId = cart.UserId,
                    Items = ToCartItemsViewModels(cart.Items).ToList(),
                    CreatedDateTime = cart.CreatedDateTime

                };
            }

            return null;
        }
        public static CartItemViewModel ToCartItemViewModel(CartItem cartDbItem)
        {
            return new CartItemViewModel
            {
                Id = cartDbItem.Id,
                Amount = cartDbItem.Amount,
                Product = ToProductViewModel(cartDbItem.Product)
            };
        }

        public static IEnumerable<CartItemViewModel> ToCartItemsViewModels(IEnumerable<CartItem> cartDbItems)
        {
            foreach (var cartDbItem in cartDbItems)
            {
                yield return new CartItemViewModel
                {
                    Id = cartDbItem.Id,
                    Amount = cartDbItem.Amount,
                    Product = ToProductViewModel(cartDbItem.Product)
                };
            }
        }
        public static FavoriteProductViewModel ToFavoriteProductViewModel(FavoriteProduct favoriteProduct)
        {
            return new FavoriteProductViewModel
            {
                Id = favoriteProduct.Id,
                UserId = favoriteProduct.UserId,
                FavoriteProducts = ToProductViewModels(favoriteProduct.Products).ToList()
            };
        }
        public static OrderViewModel ToOrderViewModel(Order order)
        {
            return new OrderViewModel
            {
                Id = order.Id,
                CreateDateTime = order.CreateDateTime,
                Status = (OrderStatusViewModel)order.Status,
                User = ToUserViewModel(order.User),
                CartItems = ToCartItemsViewModels(order.Items).ToList()
            };
        }

        public static IEnumerable<OrderViewModel> ToOrderViewModels(this IEnumerable<Order> orders)
        {
            foreach (var order in orders)
            {
                yield return ToOrderViewModel(order);
            }
        }
        public static Order ToOrder(OrderViewModel order)
        {
            return new Order
            {
                Id = order.Id,
                CreateDateTime = order.CreateDateTime,
                Status = (OrderStatus)order.Status,
            };

        }
        public static IEnumerable<CartItem> ToCartItems(IEnumerable<CartItemViewModel> cartItems)
        {
            foreach (var item in cartItems)
            {
                yield return ToCartItem(item);
            }
        }
        public static CartItem ToCartItem(CartItemViewModel cartItem)
        {
            return new CartItem
            {
                Id = cartItem.Id,
                Amount = cartItem.Amount,
                Product = ToProduct(cartItem.Product),
            };
        }
        public static Product ToProduct(this ProductViewModel product)
        {
            return new Product
            {
                Id = product.Id,
                Name = product.Name,
                Cost = product.Cost,
                Description = product.Description
            };
        }

        public static Product ToProduct(this AddProductViewModel addProductViewModel, List<string> ImagesPath)
        {
            return new Product
            {
                Name = addProductViewModel.Name,
                Cost = addProductViewModel.Cost,
                Description = addProductViewModel.Description,
                Images = ToImages(ImagesPath)
            };
        }

        public static Product ToProduct(this EditProductViewModel editProduct)
        {
            return new Product
            {
                Id = editProduct.Id,
                Name = editProduct.Name,
                Cost = editProduct.Cost,
                Description = editProduct.Description,
                Images = editProduct.ImagesPaths.ToImages()
            };
        }
        public static EditProductViewModel ToEditProductViewModel(this Product product)
        {
            return new EditProductViewModel
            {
                Id = product.Id,
                Name = product.Name,
                Cost = product.Cost,
                Description = product.Description,
                ImagesPaths = product.Images.ToPaths()
            };
        }

        public static List<Image> ToImages(this List<string> paths)
        {
            return paths.Select(x => new Image { Url = x }).ToList();
        }

        public static List<string> ToPaths(this List<Image> paths)
        {
            return paths.Select(x => x.Url).ToList();
        }

        public static UserViewModel ToUserViewModel(this User user)
        {
            return new UserViewModel
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                //Password = user.Password,
                Email = user.Email,
                Phone = user.PhoneNumber,
                AvatarPath = user.AvatarPath,
                UserName = user.UserName,
                Address = user.Address
            };
        }

        //public static User ToUser(this UserViewModel existingUser)
        //{
        //    return new User
        //    {
        //        FirstName = existingUser.FirstName,
        //        LastName = existingUser.LastName,
        //        Email = existingUser.Email,
        //        AvatarPath = existingUser.AvatarPath,
        //        //Phone = existingUser.Phone,

        //    };
        //}
        public static User Update(this User user, UserViewModel userProfile, string imagePath = null)
        {
            user.FirstName = userProfile.FirstName;
            user.LastName = userProfile.LastName;
            //user.Email = userProfile.Email;
            user.AvatarPath = imagePath ?? user.AvatarPath;
            user.PhoneNumber = userProfile.Phone;
            user.Address = userProfile.Address;
            return user;
        }
    }
}
