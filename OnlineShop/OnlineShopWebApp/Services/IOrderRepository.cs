using OnlineShopWebApp.Models;
using System;
using System.Collections.Generic;

namespace OnlineShopWebApp
{
    public interface IOrderRepository
    {
        void Add(Order order);
        List<Order> GetAll();
        Order TryGetById(Guid id);
    }
}