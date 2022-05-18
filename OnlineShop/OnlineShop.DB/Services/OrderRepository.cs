using OnlineShop.DB;
using OnlineShop.DB.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShopWebApp.Services
{
    public class OrderRepository : IOrderRepository
    {
        private readonly OnlineShopContext onlineShopContext;

        public OrderRepository(OnlineShopContext onlineShopContext)
        {
            this.onlineShopContext = onlineShopContext;
        }

        public void Add(Order order)
        {
            onlineShopContext.Orders.Add(order);
            onlineShopContext.SaveChanges();
        }

        public Order TryGetById(Guid Id)
        {
            return onlineShopContext.Orders.FirstOrDefault(x => x.Id == Id);
        }

        public List<Order> TryGetAll()
        {
            return onlineShopContext.Orders.ToList();
        }

        public Order TryGetByUserId(Guid userId)
        {
            return onlineShopContext.Orders.FirstOrDefault(x => x.UserId == userId);
        }

        public void UpdateStatus(Guid orderId, OrderStatus status)
        {

            var order = TryGetById(orderId);
            onlineShopContext.Orders.Update(order);
            onlineShopContext.SaveChanges();
        }

       
    }
}
