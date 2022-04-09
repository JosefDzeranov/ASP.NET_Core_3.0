using OnlineShopWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShopWebApp
{
    public class ProductsReposititory
    {
        private static List<Product> products = new List<Product>()
        {
            new Product("Name1", 10, "Discription", "/images/item1.png"),
            new Product("Name2", 20, "Discription", "/images/item2.png"),
            new Product("Name3", 30, "Discription", "/images/item3.png"),
            new Product("Name4", 40, "Discription", "/images/item4.png"),
            new Product("Name5", 40, "Discription", "/images/item5.png"),
            new Product("Name6", 40, "Discription", "/images/item6.png"),
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
