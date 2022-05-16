using OnlineShop.DB.Models;
using System;

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
    }

}



