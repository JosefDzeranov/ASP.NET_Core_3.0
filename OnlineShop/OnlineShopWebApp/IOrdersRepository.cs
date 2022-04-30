using OnlineShopWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShopWebApp
{
    public interface IOrdersRepository
    {
        List<Order> GetAll();
        void Add(Cart cart, User user);
        Order TryGetById(Guid id);
    }
}
