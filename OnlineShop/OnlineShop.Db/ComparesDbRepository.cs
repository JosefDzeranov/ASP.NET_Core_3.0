using Microsoft.EntityFrameworkCore;
using OnlineShop.Db.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShop.Db
{
    public class ComparesDbRepository : IComparesRepository
    {
        private readonly DatabaseContext databaseContext;

        public ComparesDbRepository(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }
        public void Add(string userId, Product product)
        {
            var existingProduct = databaseContext.ComparingProducts.FirstOrDefault(x => x.UserId == userId && x.Product.Id == product.Id);
            if (existingProduct == null)
            {
                databaseContext.ComparingProducts.Add(new ComparingProduct { UserId = userId, Product = product });
                databaseContext.SaveChanges();
            }         
        }

        public List<Product> GetCompare(string userId)
        {
            return databaseContext.ComparingProducts.Where(x => x.UserId == userId)
                .Include(x => x.Product)
                .Select(x => x.Product)
                .ToList();
        }

        public void Clear(string userId)
        {
            var existingProductsToCompare = databaseContext.ComparingProducts.Where(x => x.UserId == userId).ToList();
            databaseContext.ComparingProducts.RemoveRange(existingProductsToCompare);
            databaseContext.SaveChanges();
        }
        public void Delete(string userId, Guid productId)
        {

            var existingProductToCompare = databaseContext.ComparingProducts.FirstOrDefault(x => x.UserId == userId && x.Product.Id == productId);
            databaseContext.Remove(existingProductToCompare);
            databaseContext.SaveChanges();
        }
    }
}
