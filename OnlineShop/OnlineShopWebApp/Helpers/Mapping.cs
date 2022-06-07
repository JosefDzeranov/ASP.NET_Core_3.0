using System.Collections.Generic;
using OnlineShop.Db.Models;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Helpers
{
    public class Mapping
    {
        public static List<ProductViewModel> ToProductViewModels(List<Product> products)
        {
            List <ProductViewModel> productsViewModels = new List <ProductViewModel>();
            foreach (var product in products)
            {
                productsViewModels.Add(
                    new ProductViewModel
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
    }
}
