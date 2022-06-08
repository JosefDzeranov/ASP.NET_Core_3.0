using Microsoft.EntityFrameworkCore;
using OnlineShop.Db.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShop.Db
{
    public class OrdersDbRepository : IOrdersRepository
    {
        private readonly DatabaseContext databaseContext;

        public OrdersDbRepository(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        public List<Order> GetAll()
        {
            return databaseContext.Orders.Include(x=>x.DeliveryInformation).Include(x=>x.Items).ThenInclude(x => x.Product).ToList();
        }

        public Order TryGetById(Guid id)
        {
            return databaseContext.Orders.Include(x => x.DeliveryInformation).Include(x => x.Items).ThenInclude(x => x.Product).FirstOrDefault(x => x.Id == id);
        }
        public void Add(List<CartItem> items, DeliveryInformation deliveryInformation)
        {
            var newOrder = new Order
            {
                Id = new Guid(),
                Items = items,
                DeliveryInformation = deliveryInformation,
                Date = DateTime.Now.ToString("dd MMMM yyyy"),
                Time = DateTime.Now.ToString("HH:mm:ss")
            };

            databaseContext.Orders.Add(newOrder);
            databaseContext.SaveChanges();
        }

        public void UpdateState(Guid orderId, OrderState newState)
        {
            var existingOrder = TryGetById(orderId);
            if (existingOrder != null)
            {
                existingOrder.State = newState;
                databaseContext.SaveChanges();
            }
        }
    }
}
