using OnlineShopWebApp.Models;
using System.Collections.Generic;

namespace OnlineShopWebApp.Interface
{
    public interface IOrdersStorage
    {
        Order TryGetOrderByUserId(string userId);
        void Add(string userId, string lastname, string name, string mail, string adress);
    }
}
