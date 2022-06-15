using Microsoft.EntityFrameworkCore;
using OnlineShop.DB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.DB.Services
{
    public class FavoriteRepository : IFavoriteRepository
    {
        private readonly OnlineShopContext onlineShopContext;

        public FavoriteRepository(OnlineShopContext onlineShopContext)
        {
            this.onlineShopContext = onlineShopContext;
        }

        public async Task AddAsync(Product product, string userId)
        {
            var existingFavorite = await TryGetByUserIdAsync(userId);
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
                await onlineShopContext.Favorites.AddAsync(newFavorite);

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

            await onlineShopContext.SaveChangesAsync();
        }

        public async Task RemoveAsync(Product product, string userId)
        {
            var existingFavorite = await TryGetByUserIdAsync(userId);
            if (existingFavorite != null)
            {
                existingFavorite.Products.Remove(product);
                onlineShopContext.Favorites.Update(existingFavorite);
                if (existingFavorite.Products.Count == 0)
                {
                    onlineShopContext.Favorites.Remove(existingFavorite);
                }
            }
            await onlineShopContext.SaveChangesAsync();
        }

        public async Task<Favorite> TryGetByUserIdAsync(string userId)
        {
            return await onlineShopContext.Favorites.FirstOrDefaultAsync(x => x.UserId == userId);
        }


    }
}


