using OnlineShopWebApp.Models;

namespace OnlineShopWebApp
{
    public interface ICartBase
    {
        void Add(Product product, string userId);
        Cart TryGetByUserId(string userId);
        void DecreaseAmount(int productId, string userId);
        void Delete(string userId);
    }
}