using OnlineShopWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShopWebApp.Services
{
    public class OrderRepository : IOrderRepository
    {
        private List<Order> orders { get; set; } = new List<Order>();

        public void Add(Order order)
        {
            orders.Add(order);
        }

        public Order TryGetById(Guid Id)
        {
            return orders.FirstOrDefault(x => x.Id == Id);
        }

        public List<Order> TryGetAll()
        {
            return orders;
        }

        public Order TryGetByUserId(string userId)
        {
            return orders.FirstOrDefault(x => x.UserId == userId);
        }

        public void UpdateStatus(Guid orderId, OrderStatus status)
        {
            var oldOrder = TryGetById(orderId);
            var newOrder = oldOrder;
            newOrder.Status = status;
            orders.Remove(oldOrder);
            orders.Add(newOrder);
        }
    }
}
