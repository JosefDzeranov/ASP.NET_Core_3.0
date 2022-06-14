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
        public static Order_ViewModel ToOrder_ViewModels(Order products)
        {
            return new Order_ViewModel()
            {
                //
            }
        }
    }
}
