using OnlineShopWebApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShopWebApp.Services
{
    public class InMemoryCartRepository : ICartRepository
    {
        private readonly IProductDataSource productDataSource;

        public InMemoryCartRepository(IProductDataSource productDataSource)
        {
            this.productDataSource = productDataSource;
        }

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


        public void Add(int id)
        {
            var product = productDataSource.GetProductById(id);
            Add(product);
        }

        public void Remove(int id)
        {
            var product = productDataSource.GetProductById(id);
            Remove(product);
        }

        public void Remove(Product product)
        {
            if (CartItems.ContainsKey(product))
            {
                if (CartItems[product] > 1)
                    CartItems[product] -= 1;
                else
                    CartItems.Remove(product);
            }

        }

        public void RemoveAll()
        {
            CartItems.Clear();
        }

        public Dictionary<Product, int> CartItems { get; set; } = new Dictionary<Product, int>();

        public decimal Cost
        {
            get
            {
                return CartItems.Sum(item => item.Key.Cost * item.Value);
            }
        }
        public int Amount
        {
            get
            {
                return CartItems.Sum(item => item.Value);
            }
        }
    }
}
