using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Services
{
    public interface IFavouriteRepository
    {
        void Add(Product product, string userId);
        void Clear(Product product, string userId);
        Favourite TryGetByUserId(string userId);
    }
}