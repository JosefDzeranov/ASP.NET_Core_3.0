using System.Collections.Generic;
using OnlineShopWebApp.Models.Users.Buyer;

namespace OnlineShopWebApp.Interfase
{
    public interface IOrdersRepository
    {
        void Add(Order order);
        List<Order> GetAll();
    }
}
