using OnlineShop.Db.Models;
using OnlineShopWebApp.Models;
using System;
using System.Collections.Generic;

namespace OnlineShopWebApp.Helpers
{
    public static class Mapping
    {
        public static List<ProductViewModel> ToProductViewModels(List<Product> products)
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
                Description = product.Description,
                Pages = product.Pages
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
                UserId = cart.UserId,
                Id = cart.Id,
                Items = ToCartItemViewModels(cart.Items)
            };
        }

        public static List<CartItemViewModel> ToCartItemViewModels(List<CartItem> cartDbItems)
        {
            var cartItems = new List<CartItemViewModel>();
            foreach (var cartDbItem in cartDbItems)
            {
                var cartItem = new CartItemViewModel
                {
                    Id = cartDbItem.Id,
                    Amount = cartDbItem.Amount,
                    Product = ToProductViewModel(cartDbItem.Product)
                };
                cartItems.Add(cartItem);
            }
            return cartItems;
        }

        public static List<OrderViewModel> ToOrderViewModels(this List<Order> orders)
        {
            var ordersViewModels = new List<OrderViewModel>();
            foreach (var order in orders)
            {
                ordersViewModels.Add(ToOrderViewModel(order));
            }
            return ordersViewModels;
        }

       public static OrderViewModel ToOrderViewModel(this Order order)
        {
            return new OrderViewModel
            {
                Id = order.Id,
                Date = order.Date,
                Time = order.Time,
                Items = ToCartItemViewModels(order.Items),
                DeliveryInformation = ToDeliveryInformationViewModel(order.DeliveryInformation),
                State = (OrderStateViewModel)(int)order.State
            };
        }

        public static DeliveryInformationViewModel ToDeliveryInformationViewModel(DeliveryInformation deliveryInformation)
        {
            return new DeliveryInformationViewModel
            {
                Name = deliveryInformation.Name,
                Adress = deliveryInformation.Adress,
                Phone = deliveryInformation.Phone,
                Email = deliveryInformation.Email
            };
        }

        public static DeliveryInformation ToDbDelivery(DeliveryInformationViewModel deliveryInformation)
        {
            return new DeliveryInformation
            {
                Name = deliveryInformation.Name,
                Adress = deliveryInformation.Adress,
                Phone = deliveryInformation.Phone,
                Email = deliveryInformation.Email
            };
        }
    }
}
