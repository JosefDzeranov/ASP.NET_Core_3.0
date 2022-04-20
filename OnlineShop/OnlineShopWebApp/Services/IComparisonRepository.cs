using OnlineShopWebApp.Models;

namespace OnlineShopWebApp
{
    public interface IComparisonRepository
    {
        void Add(Product product, string userId);
    }
}