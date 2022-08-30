using Domains;
using System.Collections.Generic;

namespace OnlineShop.BL
{
    public interface ICartServicies
    {
        void Add(Product product, string userId);
        Cart TryGetByUserId(string userId);
        void DecreaseAmount(int productId, string userId);
        void Delete(string userId);
        IEnumerable<Cart> AllCarts();
        Cart TryGetByUserName(string userName);
    }
}
