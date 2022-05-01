using System.Collections.Generic;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Interfase
{
    public interface IProductStorage
    {
        List<Product> Products { get; set; }
        Product FindProduct(int productIds);
        string WriteToStorage();
        void DeleteProduct(Product product, int userId);
        void UpdateProduct(Product oldProduct, Product newProduct, int userId);
        void AddNewProduct(Product product, int userId);
    }
}
