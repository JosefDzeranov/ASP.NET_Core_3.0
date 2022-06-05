using OnlineShopWebApp.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShopWebApp.Models
{
    public class OrdersStorage : IOrdersStorage
    {
        private List<Order> orders = new List<Order>();

        private List<Cart> carts = new List<Cart>();

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
        public void Add(Order order, Customer customer, string userId)
        {
            int LastOrderNumber = 0;
            if (orders.Count > 0)
                LastOrderNumber = orders.FindLast(x => x.UserId == userId).OrderNumber;
            else
                LastOrderNumber++;

            var newOrder = new Order()
            {
                Id = Guid.NewGuid(),
                OrderNumber = LastOrderNumber,
                OrderDateTime = DateTime.Now,
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
