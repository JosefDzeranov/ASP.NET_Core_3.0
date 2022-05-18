using OnlineShop.Db.Models;

namespace OnlineShop.Db
{
    public interface IBasketStorage
    {
        Basket TryGetByUserId(string userId);
        void AddProduct(string userId, Product product);
        void RemoveProduct(string userId, Product product);
        void ClearBasket(string userId);
    }
}
