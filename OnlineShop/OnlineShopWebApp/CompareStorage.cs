using OnlineShopWebApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShopWebApp
{
    public class CompareStorage : ICompareStorage
    {
        private List<Compare> compareLists = new List<Compare>();

        public List<Compare> CompareLists
        {
            get
            {
                return compareLists;
            }
        }

        public Compare TryGetByUserId(string userId)
        {
            return compareLists.FirstOrDefault(item => item.UserId == userId);
        }

        public void AddProduct(string userId, Product product)
        {
            var compareList = TryGetByUserId(userId);

            if (compareList == null)
            {
                var newCompareList = new Compare(userId);
                newCompareList.Products.Add(product);
                compareLists.Add(newCompareList);
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

        public void RemoveProduct(string userId, Product product)
        {
            var compareList = TryGetByUserId(userId);

            if (compareList != null)
            {
                var productInList = compareList.Products.FirstOrDefault(item => item.Id == product.Id);

                if (productInList != null)
                {
                        compareList.Products.Remove(productInList);
                }
            }
        }
        public void Clear(string userId)
        {
            var compareList = TryGetByUserId(userId);
            compareList.Products.Clear();
        }
    }
}
