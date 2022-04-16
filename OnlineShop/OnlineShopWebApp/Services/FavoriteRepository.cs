using OnlineShopWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShopWebApp.Services
{
    public class FavoriteRepository : IFavoriteRepository
    {
        private List<Favorite> favorites = new List<Favorite>();

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
                favorites.Add(newFavorite);
            }
            else
            {

                var existingProduct = existingFavorite.Products.FirstOrDefault(x => x.Id == product.Id);

                if (existingProduct == null)
                {
                    existingFavorite.Products.Add(product);
                }

            }

        }

        public void Remove(Product product, string userId)
        {
            var existingFavorite = TryGetByUserId(userId);
            if (existingFavorite != null)
            {
                existingFavorite.Products.Remove(product);
            }

        }

        public Favorite TryGetByUserId(string userId)
        {
            return favorites.FirstOrDefault(x => x.UserId == userId);
        }


    }
}


