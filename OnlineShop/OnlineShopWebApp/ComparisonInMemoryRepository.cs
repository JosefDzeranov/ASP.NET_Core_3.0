using OnlineShopWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShopWebApp
{
    public class ComparisonInMemoryRepository : IComparisonRepository
    {
        private List<Compare> compares = new List<Compare>();

        public void Add(Compare compare, string userId)
        {
            compares.Add(compare);
        }

        public Compare TryGetByUserId(string userId)
        {
            return compares.FirstOrDefault(x => x.UserId == userId);
        }
    }
}
