using OnlineShopWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShopWebApp
{
    public class OrderRepository : IOrderRepository
    {
        private List<Order> orders = new List<Order>();

        public void Add(Order order)
        {
            orders.Add(order);
        }

        public List<Order> GetAll()
        {
            return orders;
        }

        public Order TryGetById(Guid id)
        {
            return orders.FirstOrDefault(x => x.Id == id);
        }
    }
}
