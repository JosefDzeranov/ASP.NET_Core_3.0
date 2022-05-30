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
        public void Add(Order order, Customer customer, string userId, CartItem cartItem)
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
                //                CostOrder = order.CostOrder,
                UserId = Constants.UserId,
                Items = new List<CartItem>
                {
                    new CartItem
                    {
                        ItemId = Guid.NewGuid(),
                        Product = cartItem.Product,
                        Count = cartItem.Count + 1
                    }
                },
                Customer = new Customer()
                {
                    LastName = customer.LastName,
                    Name = customer.Name,
                    Phone = customer.Phone,
                    Mail = customer.Mail,
                    Address = customer.Address,
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
