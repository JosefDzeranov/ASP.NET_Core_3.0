using OnlineShopWebApp.Models;

namespace OnlineShopWebApp
{
    public interface ICompareRepository
    {
        string UserId { get; set; }

        void Add(Product product, string userId);
        void Clear(Product product, string userId);
        Compare TryGetByUserId(string userId);
    }
}