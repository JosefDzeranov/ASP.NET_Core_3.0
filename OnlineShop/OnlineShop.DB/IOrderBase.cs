using Entities;
using System.Collections.Generic;

namespace OnlineShop.DB
{
    public interface IOrderBase
    {
        void Add(OrderEntity order);
        List<OrderEntity> AllOrders();
        void UpdateOrderStatus(int orderId, OrderStatusEntity status);
    }
}
