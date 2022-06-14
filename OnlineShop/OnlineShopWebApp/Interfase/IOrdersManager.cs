using System;
using System.Collections.Generic;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Interfase
{
    public interface IOrdersManager
    {
        void Add(Order order);
        List<Order> GetAll();
        Order Find(Guid orderId);
        void Buy(string buyerLogin);
        List<Order> CollectAllOrders(string buyerLogin);
        void UpdateOrderStatus(Order newOrder);
    }
}