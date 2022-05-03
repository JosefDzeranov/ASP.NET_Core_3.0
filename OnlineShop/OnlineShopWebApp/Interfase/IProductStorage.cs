using System.Collections.Generic;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Interfase
{
    public interface IProductStorage
    {
        List<Product> Products { get; set; }
        Product FindProduct(int productIds);
        string WriteToStorage();
        void DeleteProduct(Product product);
        void UpdateProduct(Product oldProduct, Product newProduct);
        void AddNewProduct(Product product);
    }
}
