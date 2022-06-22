﻿using OnlineShopWebApp.Areas.Admin.Models;
using OnlineShopWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShopWebApp
{
    public class OrdersStorage : IOrdersStorage
    {
        private List<Order> orders = new List<Order>();

        private List<CartViewModel> carts = new List<CartViewModel>();

        private List<Role> roles = new List<Role>();

        public Order TryGetOrderByUserId(string userId)
        {
            return orders.FirstOrDefault(x => x.UserId == userId);
        }

        public List<Order> TryGetAllOrders()
        {
            return orders;
        }

        public List<Order> TryGetOrderAllByUserId(string userId)
        {
            return orders.FindAll(x => x.UserId == userId);
        }
        public void Add(Order order, string userId)
        {
            orders.Add(order);

            RemoveCartUser();
        }

        public void RemoveCartUser()
        {
            carts.Clear();
        }

        public Order GetOrder(Guid orderId)
        {
            return orders.FindLast(x => x.Id == orderId);
        }

        public void SaveEditedOrder(Guid orderId, OrderState state)
        {
            var order = orders.Find(x => x.Id == orderId);
            order.State = state;
        }
    }
}
