using System;
using System.Collections.Generic;
using OnlineShop.Db.Models;
using OnlineShopWebApp.Interfase;
using Order = OnlineShopWebApp.Models.Users.Buyer.Order;

namespace OnlineShopWebApp
{
    public class CartsRepository : ICartsRepository
    {
        private IWorkWithData JsonStorage { get; } = new JsonWorkWithData(nameSave);
        private const string nameSave = "carts";
        private List<CartItem> carts = new List<CartItem>();

        public void Add(CartItem cartItem)
        {
            carts.Add(cartItem);
        }

        public List<CartItem> GetAll()
        {
            return carts;
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
