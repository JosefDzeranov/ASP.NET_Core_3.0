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

        public void Add(string userId, string lastname, string name, string mail, string adress, string phone)
        {
            int LastOrderNumber = 0;
            if (orders.Count > 0)
                LastOrderNumber = orders.FindLast(x => x.UserId == userId).OrderNumber;
            else
                LastOrderNumber++;

            var newOrder = new Order
            {
                Id = Guid.NewGuid(),
                OrderNumber = LastOrderNumber,
                OrderDate = DateTime.Now,
                LastName = lastname,
                Name = name,
                Mail = mail,
                Address = adress,
                Phone = phone,
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
            RemoveAll();
        }

        public void RemoveAll()
        {
            carts.Clear();
        }
    }
}
