using System.Collections.Generic;
using OnlineShop.db.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;


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

        public Order TryGetById(int id)
        {
            return databaseContext.Orders.FirstOrDefault(x => x.Id == id);
        }

        public List<Order> TryGetByUserId(string userId)
        {
            return databaseContext.Orders.Where(x => x.User.Id == userId).ToList();
        }

        //public List<Order> TryGetByUserId(string userId)
        //{
        //    return databaseContext.Orders.Where(x => x.UserId == userId).ToList();
        //}

        public void UpdateStatus(string orderId, OrderStatus newStatus)
        {
            var order = databaseContext.Orders.First(x => x.Id.ToString() == orderId);
            order.Status = newStatus;
            databaseContext.SaveChanges();
        }

        public void UpdateStatus(int orderId, OrderStatus newStatus)
        {
            throw new System.NotImplementedException();
        }
    }
}
