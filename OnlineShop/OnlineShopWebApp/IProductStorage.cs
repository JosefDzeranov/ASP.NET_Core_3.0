using OnlineShopWebApp.Models;
using System.Collections.Generic;

namespace OnlineShopWebApp
{
    public interface IProductStorage
    {
        List<Product> GetProductData();
        Product TryGetProduct(string id);
        void AddProduct(Product product);
        void EditProduct(Product product);
        void RemoveProduct(string id);
    }
}
