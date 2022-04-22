using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp
{
    public class InMemoryProductsRepository : IProductsRepository
    {
        private List<Product> products = new List<Product>();

        private static int constantCounter = 0;
        public List<Product> GetAll()
        {
            return products;
        }

        public Product TryGetById(int id)
        {
            foreach (var product in products)
            {
                if (product.Id == id)
                    return product;
            }
            return null;
        }
        public void Delete(int id)
        {
            var product = products.FirstOrDefault(x => x.Id == id);
            products.Remove(product);
        }

        public void Add(Information information)
        {

            var newProduct = new Product
            {
                Id = constantCounter,
                Information = information,
            };
            products.Add(newProduct);
            constantCounter++;
        }
    }
}

