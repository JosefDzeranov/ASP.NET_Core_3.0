using OnlineShop.Db.Models;

namespace OnlineShop.Db
{
    public interface IBasketStorage
    {
        Basket TryGetByUserId(string userId);
        void Add(string userId, Product product);
        void Remove(string userId, Product product);
        void Clear(string userId);
    }
}
