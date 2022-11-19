using System;
using OnlineShop.db.Models;
using System.Collections.Generic;

namespace OnlineShop.db
{
    public interface IOrdersRepository
    {
        void Add(Order order);
        
        List<Order> GetAll();
        Order TryGetById(int id);

        void UpdateStatus(int orderId, OrderStatus newStatus);

        List<Order> TryGetByUserId(string userId);

        event EventHandler<OrderStatusUpdatedEventArgs> OrderStatusUpdatedEvent;
    }
}
