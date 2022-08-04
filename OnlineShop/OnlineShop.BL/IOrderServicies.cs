using Domains;
using System.Collections.Generic;

namespace OnlineShop.BL
{
    public interface IOrderServicies
    {
        void Add(Order order);
        List<Order> AllOrders();
        void UpdateOrderStatus(int orderId, OrderStatus status);
    }
}
