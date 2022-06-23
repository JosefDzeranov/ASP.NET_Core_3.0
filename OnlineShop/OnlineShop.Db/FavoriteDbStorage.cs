using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using OnlineShop.Db.Models;
using OnlineShop.Db;

namespace OnlineShopWebApp
{
    public class FavoriteDbStorage : IFavoriteStorage
    {
        private readonly DatabaseContext databaseContext;

        public FavoriteDbStorage(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        public List<Product> GetAllByUserId(string userId)
        {
            var favoriteProduct = databaseContext.FavoriteProduct.Where(fp => fp.UserId == userId)
                                                                    .Include(fp => fp.Product)
                                                                    .Select(fp => fp.Product)
                                                                    .ToList();
            return favoriteProduct;
        }

        public void Add(string userId, Product product)
        {
            var favoriteProduct = databaseContext.FavoriteProduct.FirstOrDefault(fp => fp.UserId == userId && fp.Product == product);
            if (favoriteProduct == null)
            {
                databaseContext.FavoriteProduct.Add(new FavoriteProduct
                {
                    UserId = userId,
                    Product = product
                });

                databaseContext.SaveChanges();
            }
        }

        public void Remove(string userId, Product product)
        {
            var favoriteProduct = databaseContext.FavoriteProduct.FirstOrDefault(fp => fp.UserId == userId && fp.Product == product);
            databaseContext.FavoriteProduct.Remove(favoriteProduct);
            databaseContext.SaveChanges();
        }

        public void Clear(string userId)
        {
            var favoriteProducts = databaseContext.FavoriteProduct.Where(fp => fp.UserId == userId).ToList();
            databaseContext.FavoriteProduct.RemoveRange(favoriteProducts);
            databaseContext.SaveChanges();
        }
    }
}