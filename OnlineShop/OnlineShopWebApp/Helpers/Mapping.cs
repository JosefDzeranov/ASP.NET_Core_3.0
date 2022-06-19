using System.Collections.Generic;
using OnlineShop.Db.Models;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Helpers
{
    public class Mapping
    {
        public static List<Product_ViewModel> ToProduct_ViewModels(List<Product> products)
        {
            List <Product_ViewModel> productsViewModels = new List <Product_ViewModel>();
            foreach (var product in products)
            {
                productsViewModels.Add(
                    new Product_ViewModel
                    {
                    Id = product.Id,
                    CodeNumber = product.CodeNumber,
                    Cost = product.Cost,
                    Description = product.Description,
                    Images = product.Images,
                    Length = product.Length,
                    Square = product.Square,
                    Width = product.Width
                });
            }
            return productsViewModels;
        }
        public static Order_ViewModels ToOrder_ViewModels(Order order)
        {
            return new Order_ViewModels()
            {
                Id = order.Id,
                CreateDateTime = order.CreateDateTime,
                Status = order.Status,
                BuyerLogin = order.BuyerLogin,
                CartItems = order.CartItem,
                FullCost = order.FullCost,
                UserDeleveryInfo = order.UserDeleveryInfo
            };
        }

        public static Cart_ViewModel ToCart_ViewModels(Cart cart)
        {
            return new Cart_ViewModel()
            {
                Id = cart.Id,
                CreateDateTime = cart.CreateDateTime,
                BuyerLogin = cart.BuyerLogin,
                UserDeleveryInfo = cart.UserDeleveryInfo,
                CartItems = cart.CartItems,
                FullSumm = cart.FullSumm,
            };
        }

        public static UserDeleveryInfo_ViewModels ToUserDeleveryInfo_ViewModels(UserDeleveryInfo userDeleveryInfo)
        {
            return new UserDeleveryInfo_ViewModels()
            {
                Commentary = userDeleveryInfo.Commentary,
                Email = userDeleveryInfo.Email,
                Firstname = userDeleveryInfo.Firstname,
                Phone = userDeleveryInfo.Phone,
                Secondname = userDeleveryInfo.Secondname,
                Surname = userDeleveryInfo.Surname
            };
        }
    }
}
