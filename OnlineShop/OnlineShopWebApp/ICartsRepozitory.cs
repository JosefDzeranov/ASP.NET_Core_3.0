using OnlineShopWebApp.Models;

namespace OnlineShopWebApp
{
    public interface ICartsRepozitory
    {
        Cart TryGetByUserId(string userId);

        void Add(Product product, string userId);
    }
}