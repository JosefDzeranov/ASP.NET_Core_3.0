using OnlineShop.db.Models;
using System.Collections.Generic;
using OnlineShop.Db;
using System;


namespace OnlineShop.db
{
    public interface IOrdersRepository
    {
        void Add(Order order);
        
        List<Order> GetAll();
        Order TryGetByUserId(int id);

        void UpdateStatus(int orderId, OrderStatus newStatus);

        List<Order> TryGetByUserId(string userId);
    }
}
