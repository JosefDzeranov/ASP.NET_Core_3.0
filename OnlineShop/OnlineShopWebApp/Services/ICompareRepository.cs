using OnlineShopWebApp.Models;

namespace OnlineShopWebApp
{
    public interface ICompareRepository
    {
        void Add(Product product, string userId);
        void Clear(Product product, string userId);
        Compare TryGetByUserId(string userId);
    }
}