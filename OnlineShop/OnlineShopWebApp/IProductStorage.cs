using OnlineShopWebApp.Models;
using System.Collections.Generic;

namespace OnlineShopWebApp
{
    public interface IProductStorage
    {
        List<Product> GetProductData();
        Product TryGetProduct(string productId);
        IEnumerable<Product> SearchByName(string name);
        void AddProductToXml(Product product);
        void EditProduct(Product product);
        void RemoveProduct(string productId);
    }
}
