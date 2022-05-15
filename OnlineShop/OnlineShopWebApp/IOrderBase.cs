using OnlineShopWebApp.Models;
using System.Collections.Generic;

namespace OnlineShopWebApp
{
    public interface IOrderBase
    {
        void Add(Order order);
        IEnumerable<Order> AllOrders();
        void UpdateOrderStatus(int orderId, OrderStatus status);
    }
}
