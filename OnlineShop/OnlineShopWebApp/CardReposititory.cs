using OnlineShopWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShopWebApp
{
    public class CardRepository
    {
        private static List<Product> cards;

        public void AddProduct(Product product)
        {
            cards.Add(product);
        }

        public List<Product> GetAll()
        {
            return cards;
        }
    }
}
