using OnlineShopWebApp.Models;
using System.Collections.Generic;

namespace OnlineShopWebApp
{
    public class ProductRepository
    {
        private static List<Product> products = new List<Product>()
        {
            new Product (
                "RTX 3080", 130000, "Видеокарта из серии RTX-3"
                ),
            new Product (
                "Iphone 13 PRO", 115000, "Новый Iphone 13 PRO"
                ),
            new Product (
                "Sony PS 5", 900000, "Новинка Sony"
                ),
        };

        public List<Product> GetAllProducts()
        {
            return products;
        }
    }
}
