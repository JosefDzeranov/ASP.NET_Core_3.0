using Microsoft.EntityFrameworkCore;
using OnlineShop.DB;
using OnlineShop.DB.Models;
using OnlineShop.DB.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShopDB.Services
{
    public class ProductRepository : IProductRepository
    {
        private readonly OnlineShopContext onlineShopContext;

        public ProductRepository(OnlineShopContext onlineShopContext)
        {
            this.onlineShopContext = onlineShopContext;
        }

        public List<Product> GetAll()
        {
            return onlineShopContext.Products.ToList();
        }

        public Product TryGetById(Guid id)
        {
            return onlineShopContext.Products.FirstOrDefault(product => product.Id == id);    
        }

        public void Delete(Product product)
        {
            onlineShopContext.Products.Remove(product);
            var productInCart = onlineShopContext.CartItems.FirstOrDefault(x => x.ProductId == product.Id);
            if (productInCart != null)
            {
                onlineShopContext.CartItems.Remove(productInCart);
            }
           
            onlineShopContext.SaveChanges();
        }

        public void Add(Product product)
        {
            onlineShopContext.Products.Add(product);
            onlineShopContext.SaveChanges();
        }

        public void Update(Product product)
        {
            
            onlineShopContext.Products.Update(product);
            onlineShopContext.SaveChanges();
        }
    }
}
