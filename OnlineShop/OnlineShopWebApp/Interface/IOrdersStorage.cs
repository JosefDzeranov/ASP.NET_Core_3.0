using OnlineShopWebApp.Models;
using System;
using System.Collections.Generic;

namespace OnlineShopWebApp.Interface
{
    public interface IOrdersStorage
    {
        Order TryGetOrderByUserId(string userId);

        List<Order> TryGetOrderAllByUserId(string userId);

        void Add(Order order, string userId);

        List<Order> TryGetAllOrders();

        Order GetOrder(Guid orderId);

        void SaveEditedOrder(Guid order, OrderState state);
    }
}
