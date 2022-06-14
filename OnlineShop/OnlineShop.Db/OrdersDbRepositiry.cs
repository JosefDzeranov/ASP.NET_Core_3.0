using System;
using System.Collections.Generic;
using System.Linq;
using OnlineShop.Db.Interfase;
using OnlineShop.Db.Models;

namespace OnlineShop.Db
{
    public class OrdersDbRepositiry : IOrdersRepositiry
    {
        private readonly DatabaseContext _databaseContext;
        public OrdersDbRepositiry (DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public void Add(Order order)
        {
            _databaseContext.Orders.Add(order);
           Save();
        }

        public List<Order> GetAll()
        {
            return _databaseContext.Orders.ToList();
        }
        public Order Find(Guid orderId)
        {
            return _databaseContext.Orders.FirstOrDefault(Order => Order.Id == orderId);
        }
        public void Buy(string buyerLogin)
        {
            //var cart = _cartsManager.Find(buyerLogin);
            //orders.Add(new Order(cart.CartItems, cart.BuyerLogin, cart.UserDeleveryInfo));

            //cart.CartItems.Clear();
            //Save();
        }
        public List<Order> CollectAllOrders(string buyerLogin)
        {
            List<Order> collectAllOrders = new List<Order>();
            var orders = _databaseContext.Orders.ToList();
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
            _databaseContext.SaveChanges();
        }
    }
}