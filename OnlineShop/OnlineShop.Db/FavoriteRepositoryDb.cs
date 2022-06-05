using Microsoft.EntityFrameworkCore;
using OnlineShop.Db.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShop.Db
{
    public class FavoriteRepositoryDB : IFavoriteRepository
    {
        private readonly DataBaseContext dataBaseContext;

        public FavoriteRepositoryDB(DataBaseContext dataBaseContext)
        {
            this.dataBaseContext = dataBaseContext;
        }

        public void Add(string userId, Product product)
        {
            var existingProduct = dataBaseContext.FavoriteProducts.FirstOrDefault(x => x.UserId == userId && x.Product.Id == product.Id);
            if (existingProduct == null)
            {
                dataBaseContext.FavoriteProducts.Add(new FavoriteProduct { Product = product, UserId = userId });
                dataBaseContext.SaveChanges();
            }
        }

        public void Clear(string userId)
        {
            var userFavoriteProducts = dataBaseContext.FavoriteProducts.Where(u => u.UserId == userId).ToList();
            dataBaseContext.FavoriteProducts.RemoveRange(userFavoriteProducts);
            dataBaseContext.SaveChanges();
        }

        public List<Product> GetAll(string userId)
        {
            return dataBaseContext.FavoriteProducts.Where(x => x.UserId == userId)
                                            .Include(x => x.Product)
                                            .Select(x => x.Product)
                                            .ToList();
        }

        public void Remove(string userId, Guid productId)
        {
            var removingFavorite = dataBaseContext.FavoriteProducts.FirstOrDefault(u => u.UserId == userId && u.Product.Id == productId);
            dataBaseContext.FavoriteProducts.Remove(removingFavorite);
            dataBaseContext.SaveChanges();
        }
    }
}
