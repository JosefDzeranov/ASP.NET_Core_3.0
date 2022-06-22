using OnlineShop.Db.Models;
using System;
using System.Collections.Generic;

namespace OnlineShop.Db
{
    public interface IOrdersRepository
    {
        List<Order> GetAll();
        void Add(Cart cart, DeliveryInformation deliveryInformarion);
        Order TryGetById(Guid id);
        void UpdateState(Guid orderId, OrderState state);
        List<Order> TryGetByUserId(string id);
    }
}
