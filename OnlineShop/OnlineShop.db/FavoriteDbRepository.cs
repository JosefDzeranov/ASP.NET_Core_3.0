using System.Linq;
using System.Collections.Generic;
using OnlineShop.db.Models;
using Microsoft.EntityFrameworkCore;

namespace OnlineShop.db
{
    public class FavoriteDbRepository : IFavoriteRepository
    {
        private readonly DatabaseContext databaseContext;

        public FavoriteDbRepository(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        public void Add(string userId, Product product)
        {
            var fav = GetForUser(userId);

            if (fav.Products.Contains(product))
                return;

            fav.Products.Add(product);
        }
        public void Clear(string userId)
        {
            var fav = GetForUser(userId);
            fav.Products.Clear();
            databaseContext.SaveChanges();
        }

        public List<Product> GetAll(string userId)
        {
            return databaseContext.FavoriteProducts.FirstOrDefault(x => x.UserId == userId)?.Products;
        }

        public void Remove(string userId, int productId)
        {
            var fav = GetForUser(userId);
            var product = fav.Products.First(x=>x.Id == productId);
            fav.Products.Remove(product);
            databaseContext.SaveChanges();
        }

        public FavoriteProduct GetForUser(string userId)
        {
            var fav = databaseContext.FavoriteProducts.FirstOrDefault(u => u.UserId == userId); 

            if (fav == null)
            {
                fav = new FavoriteProduct() { UserId = userId };
                databaseContext.FavoriteProducts.Add(fav);
                databaseContext.SaveChanges();
            }

            return fav;
        }
        public FavoriteProduct TryGetByUserId(string userId)
        {
            return databaseContext.FavoriteProducts.FirstOrDefault(x => x.UserId == userId);
        }
    }
}
