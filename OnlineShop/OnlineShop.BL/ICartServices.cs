using Domains;
using System.Collections.Generic;

namespace OnlineShop.BL
{
    public interface ICartServices
    {
        void Add(Product product, string userId);
        Cart TryGetByUserId(string userId);
        void DecreaseAmount(int productId, string userId);
        void Delete(string userId);
        List<Cart> AllCarts();
        Cart TryGetByUserName(string userName);
    }
}
