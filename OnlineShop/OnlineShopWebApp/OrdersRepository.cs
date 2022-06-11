using System;
using System.Collections.Generic;
using OnlineShopWebApp.Interfase;
using OnlineShopWebApp.Models.Users.Buyer;

namespace OnlineShopWebApp
{
    public class OrdersRepository : IOrdersRepository
    {
        private IWorkWithData JsonStorage { get; } = new JsonWorkWithData(nameSave);
        private const string nameSave = "orders";
        private List<Order> orders = new List<Order>();

        public void Add(Order order)
        {
            orders.Add(order);
        }

        public List<Order> GetAll()
        {
            return orders;
        }
        public Order FindOrderItem(Guid orderId)
        {
            foreach (var buyer in orders)
            {
                var orders = buyer.Orders;
                foreach (var order in orders)
                {
                    if (order.Id == orderId)
                    {
                        return order;
                    }
                }
            }
            return null;
        }

        public List<Order> CollectAllOrders()
        {
            List<Order> collectAllOrders = new List<Order>();
            foreach (var buyer in orders)
            {
                var orders = buyer.Orders;
                foreach (var order in orders)
                {
                    collectAllOrders.Add(order);
                }
            }
            return collectAllOrders;
        }

        public void UpdateOrderStatus(Order newOrder)
        {
            var order = FindOrderItem(newOrder.Id);
            order.Status = newOrder.Status;
            JsonStorage.Write(orders);
        }
    }
}
