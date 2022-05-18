using OnlineShopWebApp.Models;

namespace OnlineShopWebApp
{
    public interface ICartsRepository
    {
        Cart TryGetByUserId(string userId);

        void Add(ProductViewModel product, string userId);

        void Delete(ProductViewModel product, string userId);
        void Clear(string userId);
    }
}