using OnlineShop.Db.Models;
using System.Collections.Generic;

namespace OnlineShop.Db
{
    public interface IFavouritesRepository
    {
        List<Product> GetFavourites(string userId);
        void Add(string userId, Product product);
        //void Clear();
        //void Delete(Product product);
    }
}
