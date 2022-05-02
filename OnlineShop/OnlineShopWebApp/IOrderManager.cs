using OnlineShopWebApp.Models;
using System;
using System.Collections.Generic;

namespace OnlineShopWebApp
{
    public interface IOrderManager
    {
        public List<Order> OrdersList { get; set; }
      
        public void SaveOrder(Order order);
        public Order TryGetOrderById(string userId);
        public Order TryGetOrderById(Guid id);
        public void UpdateStatus(Guid id, OrderStatus status);
    }
}