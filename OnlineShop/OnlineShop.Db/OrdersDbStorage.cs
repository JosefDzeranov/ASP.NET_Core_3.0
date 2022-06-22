using Microsoft.EntityFrameworkCore;
using OnlineShop.Db;
using OnlineShop.Db.Models;
using OnlineShopWebApp.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShopWebApp.Models
{
    public class OrdersDbStorage : IOrdersStorage
    {
        private readonly DatabaseContext databaseContext;

        public OrdersDbStorage(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        public Order TryGetOrderByUserId(string userId)
        {         
            return databaseContext.Orders.FirstOrDefault(x => x.UserId.ToString() == userId);
        }

        public List<Order> TryGetAllOrders()
        {
            var orders = databaseContext.Orders.Include(order => order.DeliveryInfo)
                                               .ThenInclude(adress =>adress.Address)
                                               .Include(order => order.Items)
                                               .ThenInclude(item => item.Product)
                                               .ToList();

            return orders;
        }

        public List<Order> TryGetOrderAllByUserId(string userId)
        {
            var orders = databaseContext.Orders.Where(x => x.UserId == userId).ToList();

            return orders;
        }

        public void Add(Order order, string userId, Cart cart, UserDeliveryInfo contactsinfo)
        {
            databaseContext.Orders.Add(new Order
            {
                UserId = userId,

                Items = cart.Items,

                DeliveryInfo = contactsinfo
            });

            databaseContext.SaveChanges();

            RemoveCartUser(userId);
        }

        public void RemoveCartUser(string userId)
        {
            Cart cartsUser = databaseContext.Carts.Where(c=>c.UserId.ToString() == userId).FirstOrDefault();

            databaseContext.Carts.Remove(cartsUser);

            databaseContext.SaveChanges();
        }

        public Order GetOrder(Guid orderId)
        {
            return databaseContext.Orders.Find(orderId);
        }

        public void SaveEditedOrder(Guid orderId, OrderState state)
        {
            var order = databaseContext.Orders.Find(orderId);

            order.State = state;
        }
    }
}
