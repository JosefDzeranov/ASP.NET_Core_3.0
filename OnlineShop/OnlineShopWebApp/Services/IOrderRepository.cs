using OnlineShopWebApp.Models;
using System;
using System.Collections.Generic;

namespace OnlineShopWebApp.Services
{
    public interface IOrderRepository
    {
        Order TryGetByUserId(string userId);
        List<Order> TryGetAll ();
        void Add(Order order);

        Order TryGetById(Guid Id);
    }
}
