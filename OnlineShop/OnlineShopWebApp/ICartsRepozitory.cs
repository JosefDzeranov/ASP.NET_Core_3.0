using OnlineShopWebApp.Models;

namespace OnlineShopWebApp
{
    public interface ICartsRepozitory
    {
        Cart TryGetByUserId(string userId);

        void Add(Product product, string userId);

        void Delete(Product product, string userId);
        void Clear(string userId);
    }
}