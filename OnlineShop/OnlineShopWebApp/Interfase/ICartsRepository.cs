using System.Collections.Generic;
using OnlineShopWebApp.Models.Users.Buyer;

namespace OnlineShopWebApp.Interfase
{
    public interface ICartsRepository
    {
        void Add(Order order);
        List<Order> GetAll();
    }
}
