using OnlineShopWebApp.Models;
using System.Collections.Generic;

namespace OnlineShopWebApp
{
    public interface IProductStorage
    {
        List<Product> GetProductData();
        Product TryGetProduct(int id);
        void AddProductToXml(Product product);
        void EditProduct(int id);
        void RemoveProduct(int id);
    }
}
