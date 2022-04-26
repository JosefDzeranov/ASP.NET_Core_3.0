using OnlineShopWebApp.Models;

namespace OnlineShopWebApp
{
    public interface IBasketStorage
    {
        Basket TryGetByUserId(string id);
        void AddProduct(string userId, Product product);
        void RemoveProduct(string userId, Product product);
        void ClearBasket(string userId);
    }
}
