using OnlineShop.DB.Models;
using System;

namespace OnlineShop.DB.Services
{
    public interface IFavoriteRepository
    {
        Favorite TryGetByUserId(Guid userId);

        void Add(Product product, Guid userId);
        void Remove(Product product, Guid userId);
    }
}
