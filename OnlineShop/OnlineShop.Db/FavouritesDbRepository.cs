using Microsoft.EntityFrameworkCore;
using OnlineShop.Db.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShop.Db
{
    public class FavouritesDbRepository : IFavouritesRepository
    {
        private readonly DatabaseContext databaseContext;

        public FavouritesDbRepository(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        public List<Product> GetFavourites(string userId)
        {
            return databaseContext.FavouriteProducts.Where(x => x.UserId == userId)
                .Include(x => x.Product)
                .Select(x => x.Product)
                .ToList();
        }

        public void Add(string userId, Product product)
        {
            var existingProduct = databaseContext.FavouriteProducts.FirstOrDefault(x => x.UserId == userId && x.Product.Id == product.Id);
            if (existingProduct == null)
            {
                databaseContext.FavouriteProducts.Add(new FavouriteProduct {Product = product, UserId = userId});
                databaseContext.SaveChanges();
            }
        }

        public void Clear(string userId)
        {
            var userFavouriteProducts = databaseContext.FavouriteProducts.Where(u => u.UserId == userId).ToList();
            databaseContext.FavouriteProducts.RemoveRange(userFavouriteProducts);
            databaseContext.SaveChanges();
        }
        public void Delete(string userId, Guid productId)
        {
            var removingFavourite = databaseContext.FavouriteProducts.FirstOrDefault(x => x.UserId == userId && x.Product.Id == productId);
            databaseContext.FavouriteProducts.Remove(removingFavourite);
            databaseContext.SaveChanges();
        }
    }
}
