using System;
using System.Collections.Generic;
using OnlineShop.Db.Models;

namespace OnlineShop.Db.Interfase
{
    public interface IOrdersRepositiry
    {
        void Add(Order order);
        List<Order> GetAll();
        Order Find(Guid orderId);
        void Buy(string buyerLogin);
        List<Order> CollectAllOrders(string buyerLogin);
        void UpdateOrderStatus(Order newOrder);
    }
}