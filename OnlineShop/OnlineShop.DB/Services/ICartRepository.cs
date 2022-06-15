using OnlineShop.DB.Models;
using System;
using System.Threading.Tasks;

namespace OnlineShop.DB.Services
{
    public interface ICartRepository
    {

        Task<Cart> TryGetByUserIdAsync(string userId);
        Task AddAsync(Product product, string userId);
        Task RemoveItemAsync(Guid productId, string userId);
        Task ClearAsync(string userId);
        Task<Cart> TryGetByIdAsync(Guid Id);

    }
}
