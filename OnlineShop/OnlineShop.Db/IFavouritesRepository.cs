using OnlineShop.Db.Models;
using System;
using System.Collections.Generic;

namespace OnlineShop.Db
{
    public interface IFavouritesRepository
    {
        List<Product> GetFavourites(string userId);
        void Add(string userId, Product product);
        void Clear(string userId);
        void Delete(string userId, Guid productId);
    }
}
