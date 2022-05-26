using OnlineShop.Db.Models;
using System;
using System.Collections.Generic;

namespace OnlineShop.Db
{
    public interface IFavouritesRepository
    {
        Favourite GetFavourite(string userId);
        List<Product> GetAll(string userId);
        void Add(string userId, Guid productId);
        //void Clear();
        //void Delete(Product product);
    }
}
