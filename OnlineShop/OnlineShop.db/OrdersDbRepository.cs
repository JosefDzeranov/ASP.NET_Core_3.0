using System.Collections.Generic;
using OnlineShop.db.Models;
using System.Linq;
using OnlineShop.Db;
using Microsoft.EntityFrameworkCore;
using System;


namespace OnlineShop.db
{
    public class OrdersDbRepository : IOrdersRepository
    {
        private readonly DatabaseContext databaseContext;

        public OrdersDbRepository(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        public void Add(Order order)
        {
            databaseContext.Orders.Add(order);
            databaseContext.SaveChanges();
        }

        public List<Order> GetAll()
        {
            return databaseContext.Orders.Include(x => x.User)
                .Include(x => x.Items).ThenInclude(x => x.Product).ToList();
        }

        public Order TryGetByUserId(int id)
        {
            return databaseContext.Orders.FirstOrDefault(x => x.Id == id);
        }

        public void UpdateStatus(int orderId, OrderStatus newStatus)
        {
            var order = databaseContext.Orders.First(x => x.Id == orderId);
            order.Status = newStatus;
            databaseContext.SaveChanges();
        }
    }
}
