using OnlineShop.DB.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShop.DB.Services
{
    public class FavoriteRepository : IFavoriteRepository
    {
        private readonly OnlineShopContext onlineShopContext;

        public FavoriteRepository(OnlineShopContext onlineShopContext)
        {
            this.onlineShopContext = onlineShopContext;
        }

        public void Add(Product product, string userId)
        {
            var existingFavorite = TryGetByUserId(userId);
            if (existingFavorite == null)
            {
                var newFavorite = new Favorite
                {
                    Id = Guid.NewGuid(),
                    UserId = userId,
                    Products = new List<Product>()
                    {
                        product
                    }
                };
                onlineShopContext.Favorites.Add(newFavorite);

            }
            else
            {

                var existingProduct = existingFavorite.Products.FirstOrDefault(x => x.Id == product.Id);

                if (existingProduct == null)
                {
                    existingFavorite.Products.Add(product);
                    onlineShopContext.Favorites.Update(existingFavorite);
                }

            }

            onlineShopContext.SaveChanges();
        }

        public void Remove(Product product, string userId)
        {
            var existingFavorite = TryGetByUserId(userId);
            if (existingFavorite != null)
            {
                existingFavorite.Products.Remove(product);
                onlineShopContext.Favorites.Update(existingFavorite);
                if (existingFavorite.Products.Count == 0)
                {
                    onlineShopContext.Favorites.Remove(existingFavorite);
                }
            }
            onlineShopContext.SaveChanges();
        }

        public Favorite TryGetByUserId(string userId)
        {
            return onlineShopContext.Favorites.FirstOrDefault(x => x.UserId == userId);
        }


    }
}


