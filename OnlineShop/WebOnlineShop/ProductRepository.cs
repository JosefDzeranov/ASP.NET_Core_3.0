using System.Collections.Generic;
using WebOnlineShop.Models;

namespace WebOnlineShop
{
    public class ProductRepository
    {
        private static List<Product> products = new List<Product>()
        {
            new Product("Iphone 13 PRO", 80000, "Desc1"),
            new Product("Sony PS 5", 90000, "Desc2"),
            new Product("RTX 3080", 400000, "Desc3"),
            new Product("HyperX Keybard", 7600, "Desc4"),
        };

        public List<Product> GetProducts()
        {
            return products;
        }
    }
}
