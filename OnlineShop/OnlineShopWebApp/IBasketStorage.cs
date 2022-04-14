using OnlineShopWebApp.Models;

namespace OnlineShopWebApp
{
    public interface IBasketStorage
    {
        Basket TryGetByUserId(string userId);
        void AddProduct(Product product);
        void RemoveProduct(Product product);
        void ClearBasket();
        decimal GetTotalSum();
    }
}
