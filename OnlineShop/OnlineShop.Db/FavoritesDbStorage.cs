using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using OnlineShop.Db.Models;
using OnlineShop.Db;

namespace OnlineShopWebApp
{
    public class FavoritesDbStorage : IFavoritesStorage
    {
        private readonly DatabaseContext _databaseContext;

        public FavoritesDbStorage(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public List<Product> GetAllByUserId(string userId)
        {
            var favoriteProducts = _databaseContext.FavoriteProducts.Where(fp => fp.UserId == userId)
                                                                    .Include(fp => fp.Product)
                                                                    .Select(fp => fp.Product)
                                                                    .ToList();
            return favoriteProducts;
        }

        public void Add(string userId, Product product)
        {
            var favoriteProduct = _databaseContext.FavoriteProducts.FirstOrDefault(fp => fp.UserId == userId && fp.Product == product);
            if (favoriteProduct == null)
            {
                _databaseContext.FavoriteProducts.Add(new FavoriteProduct
                {
                    UserId = userId,
                    Product = product
                });

                _databaseContext.SaveChanges();
            }
        }

        public void Remove(string userId, Product product)
        {
            var favoriteProduct = _databaseContext.FavoriteProducts.FirstOrDefault(fp => fp.UserId == userId && fp.Product == product);
            _databaseContext.FavoriteProducts.Remove(favoriteProduct);
            _databaseContext.SaveChanges();
        }

        public void Clear(string userId)
        {
            var favoriteProducts = _databaseContext.FavoriteProducts.Where(fp => fp.UserId == userId).ToList();
            _databaseContext.FavoriteProducts.RemoveRange(favoriteProducts);
            _databaseContext.SaveChanges();
        }
    }
}
