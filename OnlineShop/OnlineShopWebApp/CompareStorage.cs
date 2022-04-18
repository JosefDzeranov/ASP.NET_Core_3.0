using OnlineShopWebApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShopWebApp
{
    public class CompareStorage : ICompareStorage
    {
        private List<Basket> compareBaskets = new List<Basket>();

        public List<Basket> CompareBaskets
        {
            get
            {
                return compareBaskets;
            }
        }

        public Basket TryGetByUserId(string userId)
        {
            return compareBaskets.FirstOrDefault(b => b.UserId == userId);
        }

        public void AddProduct(string userId, Product product)
        {
            var compareBasket = TryGetByUserId(userId);

            if (compareBasket == null)
            {
                var newCompareBasket = new Basket(userId);
                newCompareBasket.Items.Add(new BasketItem(product));
                compareBaskets.Add(newCompareBasket);
            }
            else
            {
                var basketItem = compareBasket.Items.FirstOrDefault(item => item.Product.Id == product.Id);
                if (basketItem == null)
                {
                    compareBasket.Items.Add(new BasketItem(product));
                }
            }
        }

        public void RemoveProduct(string userId, Product product)
        {
            var compareBasket = TryGetByUserId(userId);

            if (compareBasket != null)
            {
                var basketItem = compareBasket.Items.FirstOrDefault(item => item.Product.Id == product.Id);

                if (basketItem != null)
                {
                        compareBasket.Items.Remove(basketItem);
                }
            }
        }
        public void ClearBasket(string userId)
        {
            var compareBasket = TryGetByUserId(userId);
            compareBasket.Items.Clear();
        }
    }
}
