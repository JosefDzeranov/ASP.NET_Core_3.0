﻿using System;
using System.Collections.Generic;
using OnlineShop.Db.Models;

namespace OnlineShop.Db
{
    public interface IOrderStorage
    {
        Order TryGetById(Guid id);
        List<Order> TryGetAllByUserId(string userId);
        void Add(string userId, Basket basket, DeliveryInfo  deliveryInfo);
        List<Order> GetAll();
        void UpdateStatus(Guid id, OrderStatus newStatus);
    }
}
