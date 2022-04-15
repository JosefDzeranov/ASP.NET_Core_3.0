using System;
using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShopWebApp
{
    public class OrderStorage: IOrderStorage
    {
        private List<Order> orders = new List<Order>();
        public List<Order> Orders
        {
            get
            {
                return orders;
            }
        }

        public Order TryGetByUserId(string userId)
        {
            return orders.FirstOrDefault(order => order.UserId == userId);
        }

        public void AddOrder(string userId, Basket basket, Delivery delivery)
        {
            var order = TryGetByUserId(userId);
            if(order == null)
            {
                var newOrder = new Order(userId, basket, delivery);
                orders.Add(newOrder);
            }
        }
    }
}
