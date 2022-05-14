using OnlineShopWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShopWebApp.Services
{
    public class FavoriteRepository : IFavoriteRepository
    {
        private List<Favorite> favorites = new List<Favorite>();

        public void Add(ProductViewModel product, string userId)
        {
            var existingFavorite = TryGetByUserId(userId);
            if (existingFavorite == null)
            {
                var newFavorite = new Favorite
                {
                    Id = Guid.NewGuid(),
                    UserId = userId,
                    Products = new List<ProductViewModel>()
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

        public void Remove(ProductViewModel product, string userId)
        {
            var existingFavorite = TryGetByUserId(userId);
            if (existingFavorite != null)
            {
                existingFavorite.Products.Remove(product);
                if (existingFavorite.Products.Count == 0)
                {
                    favorites.Remove(existingFavorite);
                }
            }

        }

        public Favorite TryGetByUserId(string userId)
        {
            return favorites.FirstOrDefault(x => x.UserId == userId);
        }


    }
}


