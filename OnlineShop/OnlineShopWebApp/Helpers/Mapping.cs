using System;
using OnlineShop.Db.Models;
using OnlineShopWebApp.Areas.Admin.Models;
using OnlineShopWebApp.Models;
using System.Collections.Generic;

namespace OnlineShopWebApp.Helpers
{
    public static class Mapping
    {      
        public static ProductViewModel ToProductViewModel(this Product product)
        {
            var productViewModel = new ProductViewModel
            {
                Id = product.Id,
                ImagePath = product.ImagePath,
                Name = product.Name,
                Cost = product.Cost,
                Description = product.Description,
                Available = product.Available
            };
            return productViewModel;
        }

        public static List<ProductViewModel> ToProductViewModels(this List<Product> products)
        {
            var productViewModels = new List<ProductViewModel>();
            foreach (var product in products)
            {
                var productViewModel = product.ToProductViewModel();
                productViewModels.Add(productViewModel);
            }
            return productViewModels;
        }

        public static Product ToProduct(this ProductViewModel productViewModel)
        {
            var product = new Product
            {
                Id = productViewModel.Id,
                ImagePath = productViewModel.ImagePath,
                Name = productViewModel.Name,
                Cost = productViewModel.Cost,
                Description = productViewModel.Description,
                Available = productViewModel.Available
            };
            return product;
        }

        public static BasketItemViewModel ToBasketItemViewModel(this BasketItem basketItem)
        {
            var basketItemViewModel = new BasketItemViewModel
            {
                Id = basketItem.Id,
                Product = basketItem.Product,
                Quantity = basketItem.Quantity
            };
            return basketItemViewModel;
        }

        public static BasketViewModel ToBasketViewModel(this Basket basket)
        {
            if (basket == null)
            {
                return null;
            }

            var items = new List<BasketItemViewModel>();

            foreach (var item in basket.Items)
            {
                items.Add(item.ToBasketItemViewModel());
            }

            var basketViewModel = new BasketViewModel
            {
                Id = basket.Id,
                UserId = basket.UserId,
                Items = items
            };

            return basketViewModel;
        }

        public static List<BasketItemViewModel> ToBasketItemViewModels(this List<BasketItem> items)
        {
            var basketItemViewModels = new List<BasketItemViewModel>();
            foreach (var item in items)
            {
                var basketItemViewModel = item.ToBasketItemViewModel();
                basketItemViewModels.Add(basketItemViewModel);
            }
            return basketItemViewModels;
        }

        public static AddressViewModel ToAddressViewModel(this Address address)
        {
            var AddressViewModel = new AddressViewModel
            {
                ZipCode = address.ZipCode,
                Country = address.Country,
                City = address.City,
                Street = address.Street,
                House = address.House,
                Apartment = address.Apartment

            };
            return AddressViewModel;
        }

        public static DeliveryInfoViewModel ToDeliveryInfoViewModel(this DeliveryInfo deliveryInfo)
        {
            var deliveryInfoViewModel = new DeliveryInfoViewModel
            {
                Address = deliveryInfo.Address.ToAddressViewModel(),
                Phone = deliveryInfo.Phone,
                Email = deliveryInfo.Email
            };
            return deliveryInfoViewModel;
        }

        public static OrderViewModel ToOrderViewModel(this Order order)
        {
            var status = (OrderStatusViewModel)(int)order.Status;

            var orderViewModel = new OrderViewModel
            {
                Id = order.Id,
                Date = order.Date,
                Status = status,
                DeliveryInfo = order.DeliveryInfo.ToDeliveryInfoViewModel(),
                Items = order.Items.ToBasketItemViewModels()
            };
            return orderViewModel;
        }

        public static List<OrderViewModel> ToOrderViewModels(this List<Order> orders)
        {
            var orderViewModels = new List<OrderViewModel>();
            foreach (var order in orders)
            {
                var orderViewModel = order.ToOrderViewModel();
                orderViewModels.Add(orderViewModel);
            }
            return orderViewModels;
        }

        public static Address ToAddress(this AddressViewModel addressViewModel)
        {
            var address = new Address
            {
                ZipCode = addressViewModel.ZipCode,
                Country = addressViewModel.Country,
                City = addressViewModel.City,
                Street = addressViewModel.Street,
                House = addressViewModel.House,
                Apartment = addressViewModel.Apartment

            };
            return address;
        }

        public static DeliveryInfo ToDeliveryInfo(this DeliveryInfoViewModel deliveryInfoViewModel)
        {
            var address = deliveryInfoViewModel.Address.ToAddress();

            var deliveryInfo = new DeliveryInfo
            {
                Address = address,
                Phone = deliveryInfoViewModel.Phone,
                Email = deliveryInfoViewModel.Email
            };
            return deliveryInfo;
        }

        public static UserViewModel ToUserViewModel(this User user)
        {
            var userViewModel = new UserViewModel
            {
                Id = Guid.Parse(user.Id),
                FirstName = user.FirstName,
                LastName = user.LastName,
                Phone = user.PhoneNumber,
                Email = user.Email
            };
            return userViewModel;
        }

        public static List<UserViewModel> ToUserViewModels(this List<User> users)
        {
            var userViewModels = new List<UserViewModel>();
            foreach(var user in users)
            {
                var userViewModel = user.ToUserViewModel();
                userViewModels.Add(userViewModel);
            }
            return userViewModels;
        }

        public static User ToUser(this SignupViewModel signup)
        {
            var user = new User
            {
                FirstName = signup.FirstName,
                LastName = signup.LastName,
                UserName = signup.Email,
                Email = signup.Email,
                PhoneNumber = signup.Phone
            };
            return user;
        }
    }
}
