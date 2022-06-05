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

        public static Product ToProduct(ProductViewModel product)
        {
            return new Product
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

        public static Cart ToCart(CartViewModel cartViewModel)
        {
            if (cartViewModel == null)
            {
                return null;
            }
            return new Cart
            {
                Id = cartViewModel.Id,
                CartLines = ToCartLines(cartViewModel.CartLines),
                UserId = cartViewModel.UserId

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

        public static List<CartLine> ToCartLines(List<CartLineViewModel> cartLinesViewModels)
        {
            var cartLines = new List<CartLine>();

            foreach (var cartLineViewModel in cartLinesViewModels)
            {
                var cartLine = new CartLine
                {
                    Id = cartLineViewModel.Id,
                    Product = ToProduct(cartLineViewModel.Product),
                    Amount = cartLineViewModel.Amount


                };
                cartLines.Add(cartLine);
            }
            return cartLines;
        }


        public static OrderViewModel ToOrderViewModel(Order order)
        {
            if (order == null)
            {
                return null;
            }

            return new OrderViewModel
            {
                Id = order.Id,
                Status = (OrderStatusViewModel)order.Status,
                OrderDate = order.OrderDate,
                UserId = order.UserId,
                Cart = ToCartViewModel(order.Cart),
                OrderData = ToOrderDataViewModel(order.OrderData)


            };
        }



        public static List<OrderViewModel> ToOrdersViewModels(List<Order> orders)
        {
            var ordersViewModels = new List<OrderViewModel>();

            foreach (var order in orders)
            {
                var orderViewModel = ToOrderViewModel(order);
                ordersViewModels.Add(orderViewModel);
            }
            return ordersViewModels;
        }

        public static OrderDataViewModel ToOrderDataViewModel(OrderData orderData)
        {
            if (orderData == null)
            {
                return null;
            }

            return new OrderDataViewModel
            {
                Id = orderData.Id,
              //  Cart = ToCartViewModel(orderData.Cart),
                Adress = orderData.Adress,
                Name = orderData.Name,
                Email = orderData.Email

            };
        }

        public static OrderStatusViewModel ToOrderStatusViewModel(OrderStatus orderStatus)
        {
            var orderStatusViewModel = new OrderStatusViewModel();
            orderStatusViewModel = (OrderStatusViewModel)orderStatus;
            return orderStatusViewModel;

        }

        public static OrderStatus ToOrderStatus(OrderStatusViewModel orderStatusViewModel)
        {
            var orderStatus = new OrderStatus();
            orderStatus = (OrderStatus)orderStatusViewModel;
            return orderStatus;

        }



        public static OrderData ToOrderData(OrderDataViewModel orderDataView)
        {
            return new OrderData
            {
                Id = orderDataView.Id,
              //  Cart = ToCart(orderDataView.Cart),
                Name = orderDataView.Name,
                Adress = orderDataView.Adress,
                Email = orderDataView.Email

            };
        }
    }
}
