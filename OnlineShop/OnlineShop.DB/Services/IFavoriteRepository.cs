using OnlineShop.DB.Models;
using System;
using System.Threading.Tasks;

namespace OnlineShop.DB.Services
{
    public interface IFavoriteRepository
    {
        Task<Favorite> TryGetByUserIdAsync(string userId);
        Task AddAsync(Product product, string userId);
        Task RemoveAsync(Product product, string userId);
    }
}
