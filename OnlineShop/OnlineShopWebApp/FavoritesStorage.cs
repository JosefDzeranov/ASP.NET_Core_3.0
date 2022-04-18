using OnlineShopWebApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShopWebApp
{
    public class FavoritesStorage : IFavoritesStorage
    {
        private List<Basket> favoritesBaskets = new List<Basket>();

        public List<Basket> FavoritesBaskets
        {
            get
            {
                return favoritesBaskets;
            }
        }

        public Basket TryGetByUserId(string userId)
        {
            return favoritesBaskets.FirstOrDefault(b => b.UserId == userId);
        }

        public void AddProduct(string userId, Product product)
        {
            var favoritesBasket = TryGetByUserId(userId);

            if (favoritesBasket == null)
            {
                var newCompareBasket = new Basket(userId);
                newCompareBasket.Items.Add(new BasketItem(product));
                favoritesBaskets.Add(newCompareBasket);
            }
            else
            {
                var basketItem = favoritesBasket.Items.FirstOrDefault(item => item.Product.Id == product.Id);
                if (basketItem == null)
                {
                    favoritesBasket.Items.Add(new BasketItem(product));
                }
            }
        }

        public void RemoveProduct(string userId, Product product)
        {
            var favoritesBasket = TryGetByUserId(userId);

            if (favoritesBasket != null)
            {
                var basketItem = favoritesBasket.Items.FirstOrDefault(item => item.Product.Id == product.Id);

                if (basketItem != null)
                {
                    favoritesBasket.Items.Remove(basketItem);
                }
            }
        }
        public void ClearBasket(string userId)
        {
            var favoritesBasket = TryGetByUserId(userId);
            favoritesBasket.Items.Clear();
        }
    }
}
