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
            return databaseContext.Favourites.FirstOrDefault(x=>x.UserId == userId).Products;
        }

        public void Add(string userId, Product product)
        {
            var existingFavourite = GetFavourites(userId);
            if (existingFavourite == null)
            {
                Favourite newFavourite = new Favourite { Id = Guid.NewGuid(), UserId = userId };
                newFavourite.Products.Add(product);
                databaseContext.Favourites.Add(newFavourite);
            }
            else
            {
                existingFavourite.Add(product);                
            }
            databaseContext.SaveChanges();
        }

        //public void Clear()
        //{
        //    favourites.Clear();
        //}
        //public void Delete(ProductViewModel product)
        //{
        //    favourites.Remove(product);
        //}
    }
}
