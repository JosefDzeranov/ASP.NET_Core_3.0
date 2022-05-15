using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Services
{
    public interface ICartRepository
    {

         Cart TryGetByUserId(string userId);
         //void Add(ProductViewModel product, string userId);
         void RemoveItem(ProductViewModel product, string userId);
         void Clear(string userId);

    }
}
