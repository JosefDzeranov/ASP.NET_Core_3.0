using OnlineShopWebApp.Models;
using System;
using System.Collections.Generic;

namespace OnlineShopWebApp
{
    public interface IOrdersRepository
    {
        List<Order> GetAll();
        void Add(CartViewModel cart, DeliveryInformarion deliveryInformarion);
        Order TryGetById(Guid id);
        void UpdateState(Guid orderId, OrderState state);
    }
}
