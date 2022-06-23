using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using OnlineShop.Db.Models;

namespace OnlineShop.Db
{
    public class CompareDbStorage : ICompareStorage
    {
        private readonly DatabaseContext _databaseContext;

        public CompareDbStorage(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public List<Product> GetAllByUserId(string userId)
        {
            var compareProducts = _databaseContext.CompareProducts.Where(cp => cp.UserId == userId)
                                                                  .Include(cp => cp.Product)
                                                                  .Select(cp => cp.Product)
                                                                  .ToList();
            return compareProducts;
        }

        public void Add(string userId, Product product)
        {
            var compareProduct = _databaseContext.CompareProducts.FirstOrDefault(cp => cp.UserId == userId && cp.Product == product);
            if (compareProduct == null)
            {
                _databaseContext.CompareProducts.Add(new CompareProduct
                {
                    UserId = userId,
                    Product = product
                });
                _databaseContext.SaveChanges();
            }
        }

        public void Remove(string userId, Product product)
        {
            var compareProduct = _databaseContext.CompareProducts.FirstOrDefault(cp => cp.UserId == userId && cp.Product == product);
            _databaseContext.CompareProducts.Remove(compareProduct);
            _databaseContext.SaveChanges();
        }

        public void Clear(string userId)
        {
            var compareProducts = _databaseContext.CompareProducts.Where(cp => cp.UserId == userId).ToList();
            _databaseContext.CompareProducts.RemoveRange(compareProducts);
            _databaseContext.SaveChanges();
        }

        public void ChangeUserId(string tempUserId, string currentUserId)
        {
            var compareProducts = _databaseContext.CompareProducts.Where(cp => cp.UserId == tempUserId).ToList();
            foreach (var cp in compareProducts)
            {
                cp.UserId = currentUserId;
            }
            _databaseContext.SaveChanges();
        }
    }
}
