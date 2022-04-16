using OnlineShopWebApp.Models;
using System.Collections.Generic;

namespace OnlineShopWebApp.Services
{
    public interface IFavoriteRepository
    {
        Favorite TryGetByUserId(string userId);

        void Add(Product product, string userId);
        void Remove(Product product, string userId);
    }
}
