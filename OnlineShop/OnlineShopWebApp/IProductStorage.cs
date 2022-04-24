using System;
using OnlineShopWebApp.Models;
using System.Collections.Generic;

namespace OnlineShopWebApp
{
    public interface IProductStorage
    {
        List<Product> GetProductData();
        Product TryGetProduct(string productId);
        void AddProductToXml(Product product);
        void EditProduct(Product product);
        void RemoveProduct(string productId);
    }
}
