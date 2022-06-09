using OnlineShop.DB.Models;
using System.Collections.Generic;

namespace OnlineShop.DB
{
    public interface ICartBase
    {
        void Add(Product product, string userId);
        Cart TryGetByUserId(string userId);
        void DecreaseAmount(int productId, string userId);
        void Delete(string userId);
        List<Cart> AllCarts();
    }
}