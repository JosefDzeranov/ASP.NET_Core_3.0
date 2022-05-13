using OnlineShopWebApp.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShopWebApp.Models
{
    public class OrdersStorage : IOrdersStorage
    {
        private List<Order> orders = new List<Order>();

        public Order TryGet(string userId)
        {
            return orders.FirstOrDefault(x => x.UserId == userId);
        }

        public List<Order> TryGetAll(string userId)
        {
            return orders.FindAll(x => x.UserId == userId);
        }


        public void Add(Order order, Customer customer, string userId)
        {
            int lastOrderNumber = 1;
            
            if (orders.Count > 0)
                lastOrderNumber = orders.FindLast(x => x.UserId == userId).OrderNumber;

            var newOrder = new Order()
            {
                Id = Guid.NewGuid(),
                OrderNumber = lastOrderNumber,
                OrderDateTime = DateTime.Now,
                UserId = userId,
                Items = new List<OrderItem>
                    {
                        new OrderItem
                        {
                            Id = Guid.NewGuid(),
                            Count = 1,
                        }
                    }
            };

            orders.Add(newOrder);
        }
    }
}
