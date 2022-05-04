using OnlineShopWebApp.Models;
using System;
using System.Collections.Generic;

namespace OnlineShopWebApp
{
    public interface IOrderManager
    {
        public List<Order> GetOrders();


        public void SaveOrder(Order order);
        public Order TryGetOrderByUserId(string userId);
        public Order TryGetOrderById(Guid id);
        public void UpdateStatus(Guid id, OrderStatus status);
    }
}