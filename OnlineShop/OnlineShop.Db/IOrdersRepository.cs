using OnlineShop.Db.Models;
using System.Collections.Generic;

namespace OnlineShop.Db
{
    public interface IOrdersRepository
    {
        void Add(Order order);
        void Create(Order order);
        List<Order> GetAll();
    }
}