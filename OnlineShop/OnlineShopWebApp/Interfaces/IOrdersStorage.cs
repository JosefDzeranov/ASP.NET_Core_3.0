using OnlineShopWebApp.Models;
using System.Collections.Generic;

namespace OnlineShopWebApp.Interface
{
    public interface IOrdersStorage
    {
        Order TryGet(string userId);

        List<Order> TryGetAll(string userId);

        void Add(Order order, Customer customer, string userId);
    }
}
