using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Services
{
    public interface ICartBase
    {
        public Cart TryGetByUserId(string userId);
        public void Add(Product product, string userId);
        public void Remove(Product product, string userId);
    }
}
