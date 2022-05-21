using OnlineShop.db.Models;
using OnlineShop.Db;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace OnlineShop.db
{ 
    public class CartsDbRepository : ICartRepository
    {
        private readonly IProductDataSource productDataSource;
        private readonly DatabaseContext databaseContext;

        public CartsDbRepository(IProductDataSource productDataSource, DatabaseContext databaseContext)
        {
            this.productDataSource = productDataSource;
            this.databaseContext = databaseContext;
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

                databaseContext.Carts.Add(cart);
             }

            var existingItem = cart.Items.Where(x=>x.Product.Id == product.Id).FirstOrDefault();

            if (existingItem == null)
            {
                existingItem= new CartItem()
                {
                    Product = product,
                    Amount = 1
                };
                cart.Items.Add(existingItem);
            }
            else
            {
                existingItem.Amount += 1;
            }
  
            databaseContext.SaveChanges();
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
            databaseContext.CartItems.Remove(existingItem);
            databaseContext.SaveChanges();
        }

        public void RemoveAll(string userId)
        {
            var cart = TryGetByUserId(userId);
            databaseContext.Carts.Remove(cart);
            databaseContext.SaveChanges();
        }

        public Cart TryGetByUserId(string userId)
        {
            return databaseContext.Carts.FirstOrDefault(x => x.UserId == userId);
        }

        public void GetAllProduct()
        {
            throw new System.NotImplementedException();
        }

        //public Dictionary<Product, int> CartItems { get; set; } = new Dictionary<Product, int>();

        //public decimal Cost
        //{
        //    get
        //    {
        //        return CartItems.Sum(item => item.Key.Cost * item.Value);
        //    }
        //}
        //public int Amount
        //{
        //    get
        //    {
        //        return CartItems.Sum(item => item.Value);
        //    }
        //}
    }
}
