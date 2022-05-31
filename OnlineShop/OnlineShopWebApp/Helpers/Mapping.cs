using OnlineShop.DB.Models;
using OnlineShopWebApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShopWebApp.Helpers
{
    public static class Mapping
    {
        public static List<ProductViewModel> ToProductViewModels(this IEnumerable<Product> products)
        {
            var productViewModels = new List<ProductViewModel>();

            foreach (var product in products)
            {
                var productViewModel = new ProductViewModel
                {
                    Id = product.Id,
                    ImgPath = product.ImgPath,
                    Name = product.Name,
                    Cost = product.Cost,
                    Description = product.Description
                };
                productViewModels.Add(productViewModel);
            }
            return productViewModels;
        }

        public static ProductViewModel ToProductViewModel(this Product product)
        {
            var productViewModel = new ProductViewModel
            {
                Id = product.Id,
                ImgPath = product.ImgPath,
                Name = product.Name,
                Cost = product.Cost,
                Description = product.Description
            };
            return productViewModel;
        }
        public static Product ToProduct(this ProductViewModel productViewModel)
        {
            var product = new Product
            {
                ImgPath = productViewModel.ImgPath,
                Name = productViewModel.Name,
                Cost = productViewModel.Cost,
                Description = productViewModel.Description
            };
            return product;
        }

        public static UserViewModel ToUserViewModel(this User user)
        {
            var userViewModel = new UserViewModel
            {
                Id = user.Id,
                Login = user.Login,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Password = user.Password,
                Phone = user.Phone,
            };
            return userViewModel;
        }

        public static User ToUser(this UserViewModel user)
        {
            var userDB = new User
            {
                Id = user.Id,
                Login = user.Login,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Password = user.Password,
                Phone = user.Phone,
            };
            return userDB;
        }

        public static OrderViewModel ToOrderViewModel(this Order order)
        {
            var viewOrder = new OrderViewModel
            {
                Carts = order.Carts.ToCartViewModels(),
                CreatedDate = order.CreatedDate,
                DeliveryInfo = order.DeliveryInfo.ToDeliveryInfModView(),
                Status = order.Status,
                Id = order.Id

            };
            return viewOrder;
        }

        public static Order ToOrder(this OrderViewModel order)
        {
            var orderDB = new Order
            {
                Carts = order.Carts.ToCarts(),
                CreatedDate = order.CreatedDate,
                DeliveryInfo = order.DeliveryInfo.ToDeliveryInfo(),
                Status = order.Status,
                Id = order.Id

            };
            return orderDB;
        }


        public static CartItemViewModel ToCartItemViewModel(this CartItem сartItem)
        {
            var CartItemViewModel = new CartItemViewModel
            {
                Id = сartItem.Id,
                ProductViewModel = сartItem.Product.ToProductViewModel(),
                Amount = сartItem.Amount
            };
            return CartItemViewModel;
        }

        public static List<CartItem> ToCartItems(this List<CartItemViewModel> cartItems)
        {
            List<CartItem> cartItemsDb = new List<CartItem>();
            foreach (var item in cartItems)
            {
                var cartItemDB = new CartItem
                {
                    Id = item.Id,
                    Amount = item.Amount,
                    Product = item.ProductViewModel.ToProduct()
                };
                cartItemsDb.Add(cartItemDB);

            }
            return cartItemsDb;
        }


        public static CartViewModel ToCartViewModel(this Cart cart)
        {
            if (cart == null)
            {
                return null;
            }

            var items = new List<CartItemViewModel>();

            foreach (var item in cart.Items)
            {
                items.Add(item.ToCartItemViewModel());
            }

            var cartViewModel = new CartViewModel
            {
                Id = cart.Id,
                UserId = cart.UserId,
                Items = items
            };

            return cartViewModel;
        }

        public static List<CartViewModel> ToCartViewModels(this List<Cart> carts)
        {
            List<CartViewModel> cartsToView = new List<CartViewModel>();
            foreach (var cart in carts)
            {
                cartsToView.Add(cart.ToCartViewModel());
            }
            return cartsToView;
        }

        public static Cart ToCart(this CartViewModel cart)
        {
            var cartDb = new Cart
            {
                Id = cart.Id,
                Items = cart.Items.ToCartItems(),
                UserId = cart.UserId
            };
            return cartDb;
        }

        public static List<Cart> ToCarts(this List<CartViewModel> carts)
        {
            List<Cart> cartsDb = new List<Cart>();
            foreach (var cart in carts)
            {
                cartsDb.Add(cart.ToCart());
            }
            return cartsDb;
        }

        public static DeliveryInfoModelView ToDeliveryInfModView(this DeliveryInfo delInfo)
        {
            var newDelInfoModView = new DeliveryInfoModelView
            {
                AdressToDelivery = delInfo.AdressToDelivery,
                Email = delInfo.Email,
                NameOfClient = delInfo.NameOfClient,
                Phone = delInfo.Phone
            };
            return newDelInfoModView;
        }

        public static DeliveryInfo ToDeliveryInfo(this DeliveryInfoModelView delInfo)
        {
            var newDelInfo = new DeliveryInfo
            {
                AdressToDelivery = delInfo.AdressToDelivery,
                Email = delInfo.Email,
                NameOfClient = delInfo.NameOfClient,
                Phone = delInfo.Phone
            };
            return newDelInfo;
        }
    }
}