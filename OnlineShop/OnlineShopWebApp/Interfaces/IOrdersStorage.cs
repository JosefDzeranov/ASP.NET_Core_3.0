using OnlineShopWebApp.Models;
using System.Collections.Generic;

namespace OnlineShopWebApp.Interface
{
    public interface IOrdersStorage
    {
        Order TryGetOrder(string userId);

        List<Order> TryGetOrders(string userId);

        void Add(Order order, Customer customer, string userId);
    }
}
