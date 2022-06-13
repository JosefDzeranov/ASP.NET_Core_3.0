using OnlineShop.DB.Models;
using System;

namespace OnlineShop.DB.Services
{
    public interface ICartRepository
    {

        Cart TryGetByUserId(string userId);
        void Add(Product product, string userId);
        void RemoveItem(Guid productId, string userId);
        void Clear(string userId);
        Cart TryGetById(Guid Id);

    }
}
