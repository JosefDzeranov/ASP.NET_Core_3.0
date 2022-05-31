using OnlineShop.DB.Models;
using System.Collections.Generic;

namespace OnlineShop.DB
{
    public interface IOrderBase
    {
        void Add(Order order);
        List<Order> AllOrders();
        void UpdateOrderStatus(int orderId, OrderStatus status);
    }
}
