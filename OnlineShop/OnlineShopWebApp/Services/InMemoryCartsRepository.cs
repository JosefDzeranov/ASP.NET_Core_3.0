using OnlineShop.db.Models;
using OnlineShop.db;
using OnlineShopWebApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShopWebApp.Services
{
    public class InMemoryCartRepository : ICartRepository
    {
        private readonly IProductDataSource productDataSource;

        private readonly List<Cart> carts = new List<Cart>();

        public InMemoryCartRepository(IProductDataSource productDataSource)
        {
            this.productDataSource = productDataSource;
        }

        public void Add(Product product, string userId)
        {
            var cart = TryGetByUserId(userId);

            if (cart == null)
            {
                cart = new Cart()
                {
                    UserId = userId,
                };

                carts.Add(cart);
            }

            var existingItem = cart.Items.Where(x=>x.Product.Id == product.Id).FirstOrDefault();

            if (existingItem == null)
            {
                cart.Items.Add(new CartItem()
                {
                    Product = product,
                    Amount = 1
                });
            }
            else
            {
                existingItem.Amount += 1;
            }
        }

        public void Add(int id, string userId)
        {
            var product = productDataSource.GetProductById(id);
            Add(product, userId);
        }

        public void Remove(int id, string userId)
        {
            var product = productDataSource.GetProductById(id);
            Remove(product, userId);
        }

        public void Remove(Product product, string userId)
        {
            var cart = TryGetByUserId(userId);

            var existingItem = cart.Items.Where(x => x.Product.Id == product.Id).First();

            if (existingItem.Amount > 1)
            {
                existingItem.Amount -= 1;
            }
            else
            {
                cart.Items.Remove(existingItem);
            }
        }

        public void RemoveAll(string userId)
        {
            var cart = TryGetByUserId(userId);
            cart.Items.Clear();
        }

        public Cart TryGetByUserId(string userId)
        {
            return carts.FirstOrDefault(x => x.UserId == userId);
        }

        public void GetAllProduct()
        {
            throw new System.NotImplementedException();
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
