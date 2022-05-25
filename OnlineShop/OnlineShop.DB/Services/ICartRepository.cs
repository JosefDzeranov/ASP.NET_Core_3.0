using OnlineShop.DB.Models;
using System;

namespace OnlineShop.DB.Services
{
    public interface ICartRepository
    {

        Cart TryGetByUserId(Guid userId);
        void Add(Product product, Guid userId);
        void RemoveItem(Guid productId, Guid userId);
        void Clear(Guid userId);
        Cart TryGetById(Guid Id);

    }
}
