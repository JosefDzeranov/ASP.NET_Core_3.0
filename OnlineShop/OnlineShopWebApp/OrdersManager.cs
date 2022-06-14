using System;
using System.Collections.Generic;
using OnlineShop.Db.Interfase;
using OnlineShopWebApp.Interfase;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp
{
    public class OrdersManager : IOrdersManager
    {
        private IWorkWithData jsonStorage { get; } = new JsonWorkWithData(nameSave);
        private const string nameSave = "orders";
        private List<Order> orders = new List<Order>();

        private readonly ICartsManager _cartsManager;
        public OrdersManager ( ICartsManager cartsManager)
        {
            _cartsManager = cartsManager;
            orders = jsonStorage.Read<List<Order>>();
        }

        public void Add(Order order)
        {
            orders.Add(order);
        }

        public List<Order> GetAll()
        {
            return orders;
        }
        public Order Find(Guid orderId)
        {
            foreach (var order in orders)
            {
                if (order.Id == orderId)
                {
                    return order;
                }
            }
            return null;
        }
        public void Buy(string buyerLogin)
        {
            var cart = _cartsManager.Find(buyerLogin);
            orders.Add(new Order(cart.CartItems, cart.BuyerLogin, cart.UserDeleveryInfo));

            cart.CartItems.Clear();
            Save();
        }
        public List<Order> CollectAllOrders(string buyerLogin)
        {
            List<Order> collectAllOrders = new List<Order>();
            foreach (var order in orders)
            {
                if (order.BuyerLogin == buyerLogin)
                {
                    collectAllOrders.Add(order);
                }
            }
            return collectAllOrders;
        }

        public void UpdateOrderStatus(Order newOrder)
        {
            var order = Find(newOrder.Id);
            order.Status = newOrder.Status;
            Save();
        }

        private void Save()
        {
            jsonStorage.Write(orders);
        }
    }
}