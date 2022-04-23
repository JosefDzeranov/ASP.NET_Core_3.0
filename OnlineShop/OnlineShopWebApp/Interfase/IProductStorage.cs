using System.Collections.Generic;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Interfase
{
    public interface IProductStorage
    {
        List<Product> Products { get; set; }
        string WriteToStorage();
        void ReadToStorage();
        Product FindProduct(int productIds);
        string ReadDataProducts();
    }
}
