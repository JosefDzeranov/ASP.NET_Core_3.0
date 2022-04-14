using OnlineShopWebApp.Models;
using System.Collections.Generic;

namespace OnlineShopWebApp.Services
{
    public interface IOrderBase
    {
        Order TryGetByUserId(string userId);
        List<Order> TryGetAll ();
        void Add(Order order);
    }
}
