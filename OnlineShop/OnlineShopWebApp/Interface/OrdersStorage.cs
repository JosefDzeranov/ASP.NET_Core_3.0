﻿using OnlineShopWebApp.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShopWebApp.Models
{
    public class OrdersStorage : IOrdersStorage
    {
        private List<Order> orders = new List<Order>();

        private List<Cart> carts = new List<Cart>();

        public Order TryGetOrderByUserId(string userId)
        {
            return orders.FirstOrDefault(x => x.UserId == userId);
        }

        public void Add(Order order, Customer customer, string userId)
        {
            int LastOrderNumber = 0;
            if (orders.Count > 0)
                LastOrderNumber = orders.FindLast(x => x.UserId == order.UserId).OrderNumber;
            else
                LastOrderNumber++;

            var newOrder = new Order()
            {
                Id = Guid.NewGuid(),
                OrderNumber = LastOrderNumber,
                OrderDateTime = DateTime.Now,
                Customer = new List<Customer>
                {
                    new Customer()
                    {
                        LastName = customer.LastName,
                        Name = customer.Name,
                        Mail = customer.Mail,
                        Address = customer.Address,
                        Phone = customer.Phone,
                    }
                },
                UserId = Constants.UserId,
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
