using OnlineShopWebApp.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShopWebApp.Models
{
    public class OrdersStorage : IOrdersStorage
    {
        private List<Order> orders { get; set; } = new List<Order>();
        private List<Cart> carts = new List<Cart>();

        public Order TryGetOrderByUserId(string userId)
        {
            return orders.FirstOrDefault(x => x.UserId == userId);
        }

        public void Add(Order order)
        {
            int LastOrderNumber = 0;
            if (orders.Count > 0)
                LastOrderNumber = orders.FindLast(x => x.UserId == order.UserId).OrderNumber;
            else
                LastOrderNumber++;

            var newOrder = new Order
            {
                Id = Guid.NewGuid(),
                OrderNumber = LastOrderNumber,
                OrderDate = DateTime.Now,
                LastName = order.LastName,
                Name = order.Name,
                Mail = order.Mail,
                Address = order.Address,
                Phone = order.Phone,
                UserId = order.UserId,
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
            RemoveAll();
        }

        public void RemoveAll()
        {
            carts.Clear();
        }
    }
}
