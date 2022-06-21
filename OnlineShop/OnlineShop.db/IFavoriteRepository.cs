using System;
using System.Collections.Generic;
using System.Text;
using OnlineShop.db.Models; 

namespace OnlineShop.db
{
   public interface IFavoriteRepository
    {
        void Add (string userId, Product product);
        void Clear(string userId);
        List<Product> GetAll(string userId);
        void Remove(string userId, int productId);
        FavoriteProduct TryGetByUserId(string userId);

    }
}
