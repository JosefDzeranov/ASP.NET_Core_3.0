using Microsoft.AspNetCore.Identity;
using OnlineShop.Db.Models;
using OnlineShopWebApp.Areas.Admin.Models;
using OnlineShopWebApp.Models;
using System;
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

        public static CartItemViewModel ToCartItemViewModel(this CartItem cartItem)
        {
            var CartItemViewModel = new CartItemViewModel
            {
                ItemId = cartItem.ItemId,
                Product = cartItem.Product,
                Count = cartItem.Count
            };
            
            return CartItemViewModel;
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

        public static List<CartItemViewModel> ToCartItemViewModels(this List<CartItem> items)
        {
            var cartItemViewModels = new List<CartItemViewModel>();
            
            foreach (var item in items)
            {
                var cartItemViewModel = item.ToCartItemViewModel();
                cartItemViewModels.Add(cartItemViewModel);
            }
            
            return cartItemViewModels;
        }

        public static DeliveryInfoViewModel ToContactsDeliveryViewModel(this UserDeliveryInfo DeliveryInfo)
        {
            var contactsDeliveryViewModel = new DeliveryInfoViewModel
            {
                Address = DeliveryInfo.Address.ToAddressViewModel(),
                Phone = DeliveryInfo.Phone,
                Email = DeliveryInfo.Email
            };
            
            return contactsDeliveryViewModel;
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

        public static UserDeliveryInfo ToContactsDelivery(this DeliveryInfoViewModel contactsDeliveryViewModel)
        {
            var address = contactsDeliveryViewModel.Address.ToAddress();
            var contactsInfo = new UserDeliveryInfo
            {
                Address = address,
                Phone = contactsDeliveryViewModel.Phone,
                Email = contactsDeliveryViewModel.Email
            };
            
            return contactsInfo;
        }

        public static OrderViewModel ToOrderViewModel(this Order order)
        {
            var orderViewModel = new OrderViewModel
            {
                Id = order.Id,
                OrderDateTime = order.Date,
                State = (OrderStateViewModel)order.State,
                //DeliveryInfo = order.DeliveryInfo,
                Items = order.Items.ToCartItemViewModels()
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

        public static UserViewModel ToUserViewModel(this User user, IList<string> userRoles)
        {
            var userViewModel = new UserViewModel
            {
                Id = Guid.Parse(user.Id),
                FirstName = user.FirstName,
                LastName = user.LastName,
                Phone = user.PhoneNumber,
                Email = user.Email,
                UserRoles = userRoles
            };
            return userViewModel;
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

        public static List<UserViewModel> ToUserViewModel(this List<User> users)
        {
            var userViewModels = new List<UserViewModel>();
            foreach (var user in users)
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

        public static RoleViewModel ToRoleViewModel(this IdentityRole role)
        {
            var roleViewModel = new RoleViewModel
            {
                Id = role.Id,
                Name = role.Name
            };
            return roleViewModel;
        }

        public static List<RoleViewModel> ToRoleViewModels(this List<IdentityRole> roles)
        {
            var roleViewModels = new List<RoleViewModel>();
            foreach (var role in roles)
            {
                var roleViewModel = role.ToRoleViewModel();
                roleViewModels.Add(roleViewModel);
            }
            return roleViewModels;
        }
    }
}