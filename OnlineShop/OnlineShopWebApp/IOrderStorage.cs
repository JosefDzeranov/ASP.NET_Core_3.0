using System;
using System.Collections.Generic;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp
{
    public interface IOrderStorage
    {
        void AddOrder(string userId, Basket basket, Delivery delivery);
        List<Order> GetOrderData();
    }
}
