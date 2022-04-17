using OnlineShopWebApp.Models;

namespace OnlineShopWebApp
{
    public interface ICompareStorage
    {
        Basket TryGetByUserId(string userId);
        void AddProduct(string userId, Product product);
        void RemoveProduct(string userId, Product product);
        void ClearBasket(string userId);
    }
}
