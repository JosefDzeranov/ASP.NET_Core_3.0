using System.Collections.Generic;
using OnlineShopWebApp.Models;
using OnlineShop.db.Models;
using System.Linq;
using System;
using OnlineShop.db;

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

        public static CartItemViewModel ToCartItemViewModel(CartItem cartDbItem)
        {

            return new CartItemViewModel
            {
                Id = cartDbItem.Id,
                Amount = cartDbItem.Amount,
                Product = ToProductViewModel(cartDbItem.Product)
            };

        }

        public static CustomerViewModel ToCustomerViewModel(Customer customer)
        {
            return new CustomerViewModel
            {
                Id = customer.Id,
                Name=customer.Name,
                Phone = customer.Phone,
                Adress = customer.Adress
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
                Status = order.Status,
                User = ToCustomerViewModel(order.User),
                CartItems = ToCartItemsViewModels(order.Items).ToList()
            };
        }

        public static IEnumerable<OrderViewModel> ToOrderViewModels(IEnumerable<Order> orders)
        {
            foreach (var order in orders)
            {
                yield return ToOrderViewModel(order);
            }
        }
        public static Order ToOrder (OrderViewModel order)
        {
            return new Order
            {
                Id = order.Id,
                CreateDateTime = order.CreateDateTime,
                Status = order.Status,
                //Items = ToCartItems(order.CartItems).ToList(),
                User = new Customer()
                {
                    Name = order.Name,
                    Phone = order.Phone,
                    Adress = order.Address
                },
            };
               
        }

        public static IEnumerable<CartItem> ToCartItems (IEnumerable<CartItemViewModel> cartItems)
        {
            foreach (var item in cartItems)
            {
                yield return ToCartItem(item);
            }
        }
        
        public static CartItem ToCartItem (CartItemViewModel cartItem)
        {
            return new CartItem
            {
                Id = cartItem.Id,
                Amount = cartItem.Amount,
                Product = ToProduct(cartItem.Product),
            };
        }

        public static Product ToProduct (ProductViewModel product)
        {
            return new Product
            {
                Id = product.Id,
                Name = product.Name,
                Cost = product.Cost,
                Description = product.Description,
                ImagePath = product.ImagePath

            };
        }

        public static Customer ToCustomer (CustomerViewModel customer)
        {
            return new Customer
            {
                Id = customer.Id,
                Name = customer.Name,
                Phone = customer.Phone,
                Adress = customer.Adress,
            };
        }
    }
}
