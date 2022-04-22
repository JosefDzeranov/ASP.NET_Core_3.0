using System.Collections.Generic;
using OnlineDesignBureauWebApp.Models;

namespace OnlineShopWebApp.Interfase
{
    public interface IProductStorage
    {
        List<Product> Products { get; set; }
        string WriteToStorage();
        void ReadToStorage();
        Product FindProduct(int productId);
        string ReadDataProducts();
    }
}
