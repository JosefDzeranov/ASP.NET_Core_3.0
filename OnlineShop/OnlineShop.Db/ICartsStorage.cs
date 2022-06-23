using OnlineShop.Db.Models;

namespace OnlineShop.Db
{
    public interface ICartsStorage
    {
        Cart TryGetByUserId(string userId);

        void Add(Product product, string userId);

        void RemoveProduct(Product product, string userId);

        void ClearCartUser(string userId);

        void RemoveCountProductCart(Product product, string userId);
    }
}
