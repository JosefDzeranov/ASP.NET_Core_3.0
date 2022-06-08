using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Db.Interfase;
using OnlineShop.Db.Models;

namespace OnlineShop.Db
{
    public class СomparisonDbRepository : IComparisonRepository
    {
        private readonly DatabaseContext databaseContext;
        public СomparisonDbRepository(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        public void Add(string userId, Product product)
        {
            var existingProduct = databaseContext.ComparisonProducts.FirstOrDefault(
                x => x.UserId == userId && x.Product.Id == product.Id
                );
            if (existingProduct == null)
            {
                databaseContext.ComparisonProducts.Add(new ComparisonProduct { Product = product, UserId = userId });
                databaseContext.SaveChanges();
            }
        }

        public void Clear(string userId)
        {
            var userСomparisonProducts = databaseContext.ComparisonProducts.Where(x => x.UserId == userId).ToList();
            databaseContext.ComparisonProducts.RemoveRange(userСomparisonProducts);
            databaseContext.SaveChanges();
        }

        public List<Product> GetAll(string userId)
        {
            return databaseContext.ComparisonProducts
                .Where(x => x.UserId == userId)
                .Include(x => x.Product)
                .Select(x => x.Product)
                .ToList();
        }

        public void Remove(string userId, Guid productId)
        {
            var removeFavorite =
                databaseContext.ComparisonProducts.FirstOrDefault
                    (u => u.UserId == userId && u.Product.Id == productId);
            databaseContext.ComparisonProducts.Remove(removeFavorite);
            databaseContext.SaveChanges();
        }
    }
}
