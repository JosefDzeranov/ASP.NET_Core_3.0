using OnlineShopWebApp.Models;

namespace OnlineShopWebApp
{
    public interface ICartBase
    {
        void Add(Product product, int userId);
        Cart TryGetByUserId(int userId);
        void DecreaseAmount(int productId, int userId);
        void Delete(int userId);
    }
}