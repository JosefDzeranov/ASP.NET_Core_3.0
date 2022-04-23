using OnlineShopWebApp.Models;

namespace OnlineShopWebApp
{
    public interface IOrderManager
    {
        public void SaveOrder(Order order);
        public Order TryGetOrderById(string userId);
    }
}