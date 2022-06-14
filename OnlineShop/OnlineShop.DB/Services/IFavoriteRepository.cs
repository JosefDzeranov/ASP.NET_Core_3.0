using OnlineShop.DB.Models;
using System;

namespace OnlineShop.DB.Services
{
    public interface IFavoriteRepository
    {
        Favorite TryGetByUserId(string userId);

        void Add(Product product, string userId);
        void Remove(Product product, string userId);
    }
}
