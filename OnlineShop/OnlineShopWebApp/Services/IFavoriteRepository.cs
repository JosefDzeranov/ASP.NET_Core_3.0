using OnlineShopWebApp.Models;
using System.Collections.Generic;

namespace OnlineShopWebApp.Services
{
    public interface IFavoriteRepository
    {
        Favorite TryGetByUserId(string userId);

        void Add(ProductViewModel product, string userId);
        void Remove(ProductViewModel product, string userId);
    }
}
