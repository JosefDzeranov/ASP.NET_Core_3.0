using OnlineShopWebApp.Models;

namespace OnlineShopWebApp
{
    public interface IOrderStorage
    {
        Order TryGetByUserId(string userId);
        void AddOrder(string userId, Basket basket, Delivery delivery);
        void SaveOrder(Order order);
    }
}
