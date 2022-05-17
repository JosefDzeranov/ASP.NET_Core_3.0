using OnlineShopWebApp.Models;
using OnlineShop.Db.Models;

namespace OnlineShopWebApp
{
    public interface IBasketStorage
    {
        Basket TryGetByUserId(string userId);
        void AddProduct(string userId, Product product);
        void RemoveProduct(string userId, Product product);
        void ClearBasket(string userId);
    }
}
