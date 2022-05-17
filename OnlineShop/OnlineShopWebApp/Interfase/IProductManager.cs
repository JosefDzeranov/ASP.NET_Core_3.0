using System;
using System.Collections.Generic;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Interfase
{
    public interface IProductManager
    {
        List<Product> Products { get; set; }
        Product FindProduct(Guid productId);
        void DeleteProduct(Product product);
        void UpdateProduct(Product product);
        void AddNewProduct(Product product);
    }
}
