using Microsoft.EntityFrameworkCore;
using OnlineShop.Db.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShop.Db
{
    public class OrdersRepositoryDb : IOrdersRepository
    {
        private readonly DataBaseContext dataBaseContext;

        public OrdersRepositoryDb(DataBaseContext dataBaseContext)
        {
            this.dataBaseContext = dataBaseContext;
        }

        public void Add(Order order)
        {
            dataBaseContext.Orders.Add(order);
            dataBaseContext.SaveChanges();
        }
        public List<Order> GetAll()
        {
            return dataBaseContext.Orders.Include(x => x.User)
                .Include(x => x.Items).ThenInclude(x => x.Product).ToList();
        }
        public void Create(Order order)
        {
            throw new NotImplementedException();
        }

    }
}
