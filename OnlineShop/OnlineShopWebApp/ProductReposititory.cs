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
            new Product("Name1", 10, "Discription"),
            new Product("Name2", 20, "Discription"),
            new Product("Name3", 30, "Discription"),
            new Product("Name4", 40, "Discription"),
        };

        public List<Product> GetAll()
        {
            return products;
        }

        public Product TryGetById(int id)
        {
            foreach (var product in products)
            {
                if (product.Id==id)
                {
                    return product;
                }
            }

            return null;
        }
    }
}
