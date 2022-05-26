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

        public Favourite GetFavourite(string userId)
        {
            
            return databaseContext.Favourites.Include(x => x.Products).FirstOrDefault(x => x.UserId == userId);
        }

        public List<Product> GetAll(string userId)
        {            
            var existingFavourite = databaseContext.Favourites.Include(x => x.Products).FirstOrDefault(x => x.UserId == userId);
            return existingFavourite.Products.ToList();
        }

        public void Add(string userId, Guid productId)
        {
            var existingFavourite = GetFavourite(userId);
            var favouriteId = existingFavourite.FavouriteId;
            //if (existingFavourite == null)
            //{
            //    Favourite newFavourite = new Favourite { Id = Guid.NewGuid(), UserId = userId };
            //    newFavourite.Products.Add(product);
            //    databaseContext.Favourites.Add(newFavourite);
            //}
            //else
            //{
            //    existingFavourite.Add(product);                
            //}
            databaseContext.FavouriteProducts.Add(new FavouriteProducts() { FavouriteId = favouriteId, ProductId = productId });
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
