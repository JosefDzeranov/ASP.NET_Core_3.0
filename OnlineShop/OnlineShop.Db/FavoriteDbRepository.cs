﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Db.Interfase;
using OnlineShop.Db.Models;

namespace OnlineShop.Db
{
    public class FavoriteDbRepository: IFavoriteRepository
    {
        private readonly DatabaseContext databaseContext;
        public FavoriteDbRepository(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        public void Add(string userId, Product product)
        {
            var existingProduct = databaseContext.favoriteProducts.FirstOrDefault(
                x => x.UserId == userId && x.Product.Id == product.Id
                );
            if (existingProduct == null)
            {
                databaseContext.favoriteProducts.Add(new FavoriteProduct { Product = product, UserId = userId });
                databaseContext.SaveChanges();
            }
        }

        public void Clear(string userId)
        {
            var userFavoriteProducts = databaseContext.favoriteProducts.Where(x => x.UserId == userId).ToList();
            databaseContext.favoriteProducts.RemoveRange(userFavoriteProducts);
            databaseContext.SaveChanges();
        }

        public List<Product> GetAll(string userId)
        {
            return databaseContext.favoriteProducts
                .Where(x => x.UserId == userId)
                .Include(x => x.Product)
                .Select(x => x.Product)
                .ToList();
        }

        public void Remove(string userId, Guid productId)
        {
            var removeFavorite =
                databaseContext.favoriteProducts.FirstOrDefault
                    (u => u.UserId == userId && u.Product.Id == productId);
            databaseContext.favoriteProducts.Remove(removeFavorite);
            databaseContext.SaveChanges();
        }
    }
}
