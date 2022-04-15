using OnlineShopWebApp.Models;

namespace OnlineShopWebApp
{
    interface IOrderStorage
    {
        Order TryGetByUserId(string userId);
        void AddOrder(string userId, Basket basket, Delivery delivery);
    }
}
