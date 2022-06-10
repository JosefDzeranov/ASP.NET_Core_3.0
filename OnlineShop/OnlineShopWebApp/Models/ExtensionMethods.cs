using OnlineShop.DB.Models;
using OnlineShopWebApp.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

namespace OnlineShopWebApp.Models
{
    public static class ExtensionMethods
    {
        public static Product MappingToProduct(this ProductViewModel productViewModel)
        {
            var productDb = new Product
            {
                Id = productViewModel.Id == null ? Guid.NewGuid() : productViewModel.Id,
                Name = productViewModel.Name,
                Cost = productViewModel.Cost,
                Description = productViewModel.Description,
                ImgPath = productViewModel.ImgPath,

            };

            return productDb;
        }
        public static ProductViewModel MappingToProductViewModel(this Product product)
        {
            var productViewModel = new ProductViewModel
            {
                Id = product.Id,
                Name = product.Name,
                Cost = product.Cost,
                Description = product.Description,
                ImgPath = product.ImgPath,

            };

            return productViewModel;
        }

        public static List<ProductViewModel> MappingToListProductViewModel(this List<Product> products)
        {
            var productsViewModel = new List<ProductViewModel>();

            foreach (var product in products)
            {
                var productViewModel = product.MappingToProductViewModel();
                productsViewModel.Add(productViewModel);
            }
            return productsViewModel;
        }

        public static CartViewModel MappingToCartViewModel(this Cart cart)
        {
            var cartViewModel = new CartViewModel
            {
                Id = cart.Id,
                Items = new List<CartItemViewModel>(),
                UserId = cart.UserId
            };

            foreach (var item in cart.Items)
            {
                var cartItemViewModel = new CartItemViewModel
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
                cartViewModel.Items.Add(cartItemViewModel);
            }

            return cartViewModel;
        }

        public static Order MappingToOrder(this OrderViewModel orderViewModel, Cart existingCart)
        {
            var order = new Order
            {
                Id = orderViewModel.Id,
                Email = orderViewModel.Email,
                Address = orderViewModel.Address,
                CartItems = existingCart.Items,
                Created = orderViewModel.Created,
                FirstName = orderViewModel.FirstName,
                LastName = orderViewModel.LastName,
                Phone = orderViewModel.Phone,
                Status = orderViewModel.Status,
                UserId = orderViewModel.UserId

            };
            return order;
        }

        public static OrderViewModel MappingToOrderViewModel(this Order order)
        {
            var orderViewModel = new OrderViewModel
            {
                Id = order.Id,
                Email = order.Email,
                Address = order.Address,
                Cart = new CartViewModel
                {
                    Items = new List<CartItemViewModel>(),
                },
                Created = order.Created,
                FirstName = order.FirstName,
                LastName = order.LastName,
                Phone = order.Phone,
                Status = order.Status,
                UserId = order.UserId
            };

            foreach (var item in order.CartItems)
            {
                var cartItemViewModel = new CartItemViewModel
                {
                    Id = item.Id,
                    Product = item.Product.MappingToProductViewModel(),
                    Quantinity = item.Quantinity,
                };
                orderViewModel.Cart.Items.Add(cartItemViewModel);
            }
            return orderViewModel;
        }
        public static List<OrderViewModel> MappingListOrderViewModel(this List<Order> orders)
        {
            var ordersViewModel = new List<OrderViewModel>();

            foreach (var order in orders)
            {
                var orderViewModel = order.MappingToOrderViewModel();
                ordersViewModel.Add(orderViewModel);
            }
            return ordersViewModel;
        }
        public static string GetEnumDisplayName(this Enum enumValue)
        {
            return enumValue.GetType()
                            .GetMember(enumValue.ToString())
                            .First()
                            .GetCustomAttribute<DisplayAttribute>()
                            .GetName();
        }


        public static UserViewModel MappingToUserViewModel(this User user)
        {
            var userViewModel = new UserViewModel
            {
                Id = user.Id,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Phone = user.PhoneNumber

            };
            return userViewModel;
        }

        public static List<UserViewModel> MappingToListUserViewModel(this List<User> users)
        {
            var usersViewModel = new List<UserViewModel>();

            foreach(var user in users)
            {
                usersViewModel.Add(MappingToUserViewModel(user));
            }
           
            return usersViewModel;
        }

        public static User MappingToUserFromRegisterViewModel(this RegisterViewModel regiserViewModel)
        {
            var user = new User
            {
                Email = regiserViewModel.Email,
                UserName = regiserViewModel.Email,
                FirstName = regiserViewModel.FirstName,
                LastName = regiserViewModel.LastName,
                PhoneNumber = regiserViewModel.PhoneNumber,
            };
            return user;
        }

        public static UserInfoViewModel MappingToUserInfoViewModel(this User user)
        {
            var userInfoViewModel = new UserInfoViewModel
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
            };
            return userInfoViewModel;
        }


        public static User MappingToUserFromUserInfoViewModel(this UserInfoViewModel userInfoViewModel, User user)
        {

            user.UserName = userInfoViewModel.Email;
            user.FirstName = userInfoViewModel.FirstName;
            user.LastName = userInfoViewModel.LastName;
            user.Email = userInfoViewModel.Email;
            user.PhoneNumber = userInfoViewModel.PhoneNumber;
            
            return user;
        }

        public static Product MappingToProduct(this AddProductViewModel addProductViewModel, List<string> filePaths)
        {
            return new Product
            {
                Name = addProductViewModel.Name,
                Cost = addProductViewModel.Cost,
                Description = addProductViewModel.Description,
                Images = filePaths.MappingToImages()
            };
        }

        public static List<Image> MappingToImages(this List<string> paths)
        {
            return paths.Select(p => new Image { Path = p}).ToList();
        }
    }

}



