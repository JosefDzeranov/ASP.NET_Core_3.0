using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Services
{
    public interface ICartBase
    {

         Cart TryGetByUserId(string userId);
         void Add(Product product, string userId);
         void RemoveItem(Product product, string userId);
         void Clear(string userId);

    }
}
