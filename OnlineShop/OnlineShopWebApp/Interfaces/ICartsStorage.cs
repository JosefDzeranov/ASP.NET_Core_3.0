using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Interface
{
    public interface ICartsStorage
    {
        Cart TryGetByUserId(string userId);

        void Add(Product product, string userId);

        void RemoveProduct(int productId, string userId);

        void RemoveCartUser(string userId);

        void RemoveCountProductCart(int productId, string userId);
    }
}
