using OnlineShopWebApp.Models;
using System.Collections.Generic;

namespace OnlineShopWebApp.Services
{
    public interface IFavorites
    {
        Favorite TryGetByUserId(string userId);

        void Add(Product product, string userId);
    }
}
