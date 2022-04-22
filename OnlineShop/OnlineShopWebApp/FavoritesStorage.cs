using OnlineShopWebApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShopWebApp
{
    public class FavoritesStorage : IFavoritesStorage
    {
        private List<Favorites> favoritesLists = new List<Favorites>();

        public Favorites TryGetByUserId(string userId)
        {
            return favoritesLists.FirstOrDefault(item => item.UserId == userId);
        }

        public void AddProduct(string userId, Product product)
        {
            var favoritesList = TryGetByUserId(userId);

            if (favoritesList == null)
            {
                var newfavoritesList = new Favorites(userId);
                newfavoritesList.Products.Add(product);
                favoritesLists.Add(newfavoritesList);
            }
            else
            {
                var productInList = favoritesList.Products.FirstOrDefault(item => item.Id == product.Id);
                if (productInList == null)
                {
                    favoritesList.Products.Add(product);
                }
            }
        }

        public void RemoveProduct(string userId, Product product)
        {
            var favoritesList = TryGetByUserId(userId);

            if (favoritesList != null)
            {
                var productInList = favoritesList.Products.FirstOrDefault(item => item.Id == product.Id);

                if (productInList != null)
                {
                    favoritesList.Products.Remove(productInList);
                }
            }
        }
        public void Clear(string userId)
        {
            var favoritesList = TryGetByUserId(userId);
            favoritesList.Products.Clear();
        }
    }
}
