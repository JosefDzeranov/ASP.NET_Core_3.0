using OnlineShop.DB.Models;
using System.Collections.Generic;

namespace OnlineShop.DB
{
    public interface ICartBase
    {
        void Add(Product product, int userId);
        Cart TryGetByUserId(int userId);
        void DecreaseAmount(int productId, int userId);
        void Delete(int userId);
        List<Cart> AllCarts();
    }
}