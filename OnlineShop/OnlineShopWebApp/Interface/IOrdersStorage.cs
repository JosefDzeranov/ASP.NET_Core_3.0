using OnlineShopWebApp.Models;
using System.Collections.Generic;

namespace OnlineShopWebApp.Interface
{
    public interface IOrdersStorage
    {
        Order TryGetOrderByUserId(string userId);

        List<Order> TryGetOrderAllByUserId(string userId);

        void Add(Order order, Customer customer, string userId);
    }
}
