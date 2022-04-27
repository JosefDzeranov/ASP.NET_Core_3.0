using OnlineShopWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShopWebApp
{
    public class CompareRepository : ICompareRepository
    {
        private List<Compare> compares = new List<Compare>();

        public Compare TryGetByUserId(string userId)
        {
            return compares.FirstOrDefault(x => x.UserId == userId);
        }

        public void Add(Product product, string userId)
        {
            var existingCompare = TryGetByUserId(userId);
            if (existingCompare == null)
            {
                var newCompare = new Compare()
                {
                    Id = Guid.NewGuid(),
                    UserId = userId,
                    Products = new List<Product>()
                    {
                        product
                    }
                };
                compares.Add(newCompare);
            }
            else
            {
                var existingProduct = existingCompare.Products.FirstOrDefault(x => x.Id == product.Id);
                if (existingCompare != null)
                {
                    existingCompare.Products.Add(product);
                }
            }
        }
        public void Clear(Product product, string userId)
        {
            var existingCompare = TryGetByUserId(userId);
            compares.Remove(existingCompare);
        }
    }
}