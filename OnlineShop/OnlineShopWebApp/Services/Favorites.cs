using OnlineShopWebApp.Models;
using System.Collections.Generic;

namespace OnlineShopWebApp.Services
{
    public class Favorites : IFavorites
    {
        private static List<Product> products = new List<Product>();

        public void Add(Product product)
        {
            products.Add(product);
        }

        public List<Product> GetAll()
        {
            return products;
        }

        public Product TryGetById(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}

   
