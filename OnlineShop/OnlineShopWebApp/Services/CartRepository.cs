using OnlineShopWebApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShopWebApp.Services
{
    public class CartRepository
    {

        public void Add(Product product)
        {
            if (CartItems.ContainsKey(product))
            {
                CartItems[product] += 1;
            }
            else
            {
                CartItems.Add(product, 1);
            }

        }
        public Dictionary<Product, int> CartItems { get; set; } = new Dictionary<Product, int>();

        public decimal Cost
        {
            get
            {
                return CartItems.Sum(item => item.Key.Cost * item.Value);
            }
        }

    }
}
