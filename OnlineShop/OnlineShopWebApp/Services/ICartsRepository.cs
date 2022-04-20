using OnlineShopWebApp.Models;

namespace OnlineShopWebApp
{
    public interface ICartsRepository
    {
        void Add(Product product, string userId);
        Cart TryGetByUserId(string userId);
        void DecreaseAmount(int productId, string userId);
        void Clear(string userId);
    }
}