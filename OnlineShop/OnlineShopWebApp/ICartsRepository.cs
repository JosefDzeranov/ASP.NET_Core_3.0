using OnlineShopWebApp.Models;

namespace OnlineShopWebApp
{
        public interface ICartsRepository
        {
            Cart TryGetByUserId(string userId);
            void Add(Product product, string userId);
            void Remove(Product product, string userId);
        }
    
}
