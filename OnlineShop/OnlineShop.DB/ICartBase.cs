using Entities;
using System.Collections.Generic;

namespace OnlineShop.DB
{
    public interface ICartBase
    {
        void Add(ProductEntity product, string userId);
        CartEntity TryGetByUserId(string userId);
        void DecreaseAmount(int productId, string userId);
        void Delete(string userId);
        IEnumerable<CartEntity> AllCarts();
        CartEntity TryGetByUserName(string userName);
    }
}