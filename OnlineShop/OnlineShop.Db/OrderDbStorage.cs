using System;
using OnlineShop.Db.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace OnlineShop.Db
{
    public class OrderDbStorage : IOrderStorage
    {
        private readonly DatabaseContext _databaseContext;

        public OrderDbStorage(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public Order TryGetById(Guid id)
        {
            var order = _databaseContext.Orders.Include(order => order.DeliveryInfo)
                                                .ThenInclude(di => di.Address)
                                                .Include(order => order.Items)
                                                .ThenInclude(item => item.Product)
                                                .FirstOrDefault(order => order.Id == id);

            return order;
        }

        public List<Order> GetAll()
        {
            var orders = _databaseContext.Orders.Include(order => order.DeliveryInfo)
                                                .ThenInclude(di => di.Address)
                                                .Include(order => order.Items )
                                                .ThenInclude(item => item.Product)
                                                .ToList();
            return orders;
        }

        public void Add(string userId, Basket basket, DeliveryInfo deliveryInfo)
        {
            _databaseContext.Orders.Add(new Order
            {
                UserId = userId,
                Items = basket.Items,
                DeliveryInfo = deliveryInfo
            });
            _databaseContext.SaveChanges();
        }

        public void UpdateStatus(Guid id, OrderStatus newStatus)
        {
            var order = _databaseContext.Orders.FirstOrDefault(order => order.Id == id);
            order.Status = newStatus;
            _databaseContext.SaveChanges();

        }
    }
}
