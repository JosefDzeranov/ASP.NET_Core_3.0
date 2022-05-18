using OnlineShop.DB.Models;
using System;
using System.Collections.Generic;

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
        public static List<OrderItem> MappingListOrderItem(this List<CartItemViewModel> cartItemsViewModel, Guid orderViewModelId)
        {

            var orderItems = new List<OrderItem>();
            foreach (var item in cartItemsViewModel)
            {

                var orderItem = new OrderItem
                {
                    Id = item.Id,
                    Product = item.Product.MappingProduct(),
                    Quantinity = item.Quantinity,
                    OrderId = orderViewModelId
                };
                orderItems.Add(orderItem);   
            }
            return orderItems;
        }
            public static Order MappingOrder(this OrderViewModel orderViewModel)
            {
                var order = new Order()
                {
                    Id = orderViewModel.Id == null ? Guid.NewGuid() : orderViewModel.Id,
                    FirstName = orderViewModel.FirstName,
                    LastName = orderViewModel.LastName,
                    Address = orderViewModel.Address,
                    Email = orderViewModel.Email,
                    Created = orderViewModel.Created,
                    OrderItems = orderViewModel.Cart.Items.MappingListOrderItem(orderViewModel.Id),
                    Phone = orderViewModel.Phone,
                    Status = OrderStatus.New,
                    TotalCost = orderViewModel.TotalCost,
                    UserId = orderViewModel.UserId,

                };
                return order;
            }

        }

    }



