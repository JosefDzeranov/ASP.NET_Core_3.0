using System;
using OnlineShop.db.Models;
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
                    CreatedDateTime = DateTime.Now,
                    UserId = userId
                };

                databaseContext.Carts.Add(cart);
            }

            var existingItem = cart.Items.FirstOrDefault(x => x.Product.Id == product.Id);

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

            var existingItem = cart.Items.First(x => x.Product.Id == product.Id);

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
            return databaseContext.Carts.Include(x=> x.Items).FirstOrDefault(x => x.UserId == userId);
        }

        public void GetAllProduct()
        {
            throw new System.NotImplementedException();
        }

    }
}
