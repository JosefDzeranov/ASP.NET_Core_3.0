using OnlineShop.Db.Models;
using System;
using System.Collections.Generic;

namespace OnlineShopWebApp.Interface
{
    public interface IOrdersStorage
    {
        Order TryGetOrderByUserId(string userId);

        List<Order> TryGetOrderAllByUserId(string userId);

        void Add(Order order, string userId, Cart cart, ContactsDelivery contactsinfo);

        List<Order> TryGetAllOrders();

        Order GetOrder(Guid orderId);

        void SaveEditedOrder(Guid order, OrderState state);

        void RemoveCartUser(string userId);
    }
}
