using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Interface
{
    public interface IOrdersStorage
    {
        Order TryGetOrderByUserId(string userId);

        void Add(Order order, Customer customer, string userId);
    }
}
