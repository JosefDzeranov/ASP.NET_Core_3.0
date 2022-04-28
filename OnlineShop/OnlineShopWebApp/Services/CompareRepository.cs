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
            var compareList = TryGetByUserId(userId);

            if (compareList == null)
            {
                var newCompareList = new Compare(userId);
                newCompareList.Products.Add(product);
                compares.Add(newCompareList);
            }
            else
            {
                var productInList = compareList.Products.FirstOrDefault(item => item.Id == product.Id);
                if (productInList == null)
                {
                    compareList.Products.Add(product);
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