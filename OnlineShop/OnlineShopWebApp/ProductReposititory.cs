using OnlineShopWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShopWebApp
{
    public class ProductReposititory
    {
        private static List<Product> products = new List<Product>()
        {
            new Product("Name1", 10, "Disc1"),
            new Product("Name2", 20, "Disc2"),
            new Product("Name3", 30, "Disc3"),
            new Product("Name4", 40, "Disc4"),
        };

        public List<Product> GetAll()
        {
            return products;
        }
    }
}
