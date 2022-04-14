using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Services
{
    public interface IOrderBase
    {
        Cart TryGetByUserId(string userId);

        void Add(Cart cart);
    }
}
