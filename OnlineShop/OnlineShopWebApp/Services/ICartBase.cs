using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Services
{
    public interface ICartBase
    {

         Cart TryGetByUserId(string userId);
         void Add(Product product, string userId);
         void Remove(Product product, string userId);
         void RemoveAll(string userId);

    }
}
