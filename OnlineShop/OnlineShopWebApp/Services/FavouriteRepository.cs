using OnlineShopWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShopWebApp.Services
{
    public class FavouriteRepository : IFavouriteRepository
    {
        private List<Favourite> favourite = new List<Favourite>();

        public Favourite TryGetByUserId(string userId)
        {
            return favourite.FirstOrDefault(x => x.UserId == userId);
        }

        public void Add(Product product, string userId)
        {
            var existingFavourite = TryGetByUserId(userId);
            if (existingFavourite == null)
            {
                var newFavourite = new Favourite()
                {
                    Id = Guid.NewGuid(),
                    UserId = userId,
                    Products = new List<Product>()
                    {
                        product
                    }
                };

                favourite.Add(newFavourite);
            }
            else
            {
                var existingProduct = existingFavourite.Products.FirstOrDefault(x => x.Id == product.Id);
                if (existingProduct != null)
                {
                    existingFavourite.Products.Add(product);
                }
            }
        }
        public void Clear(Product product, string userId)
        {
            var existingFavourite = TryGetByUserId(userId);
            favourite.Remove(existingFavourite);
        }
    }
}
