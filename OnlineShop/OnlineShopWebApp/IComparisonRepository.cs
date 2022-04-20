using OnlineShopWebApp.Models;

namespace OnlineShopWebApp
{
    public interface IComparisonRepository
    {
        Compare TryGetByUserId(string userId);
        void Add(Product product, string userId);
    }
}