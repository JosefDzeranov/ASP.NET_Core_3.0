using OnlineShop.DB.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

namespace OnlineShopWebApp.Models
{
    public static class ExtensionMethods
    {
        public static Product MappingProduct(this ProductViewModel productViewModel)
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
        public static ProductViewModel MappingProductViewModel(this Product product)
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

        public static List<ProductViewModel> MappingListProductViewModel(this List<Product> products)
        {
            var productsViewModel = new List<ProductViewModel>();

            foreach (var product in products)
            {
                var productViewModel = product.MappingProductViewModel();
                productsViewModel.Add(productViewModel);
            }
            return productsViewModel;
        }

        public static CartViewModel MappingCartViewModel(this Cart cart)
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

        public static Order MappingOrder(this OrderViewModel orderViewModel, Cart existingCart)
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

        public static OrderViewModel MappingOrderViewModel(this Order order)
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
                    Product = item.Product.MappingProductViewModel(),
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
                var orderViewModel = order.MappingOrderViewModel();
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
    }


}



