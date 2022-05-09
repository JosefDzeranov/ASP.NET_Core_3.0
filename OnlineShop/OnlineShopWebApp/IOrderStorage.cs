using System;
using System.Collections.Generic;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp
{
    public interface IOrderStorage
    {
        Order TryGetById(Guid id);
        void AddOrder(string userId, Basket basket, Delivery delivery);
        List<Order> GetOrderData();
        void UpdateStatus(Guid id, OrderStatus newStatus);
    }
}
