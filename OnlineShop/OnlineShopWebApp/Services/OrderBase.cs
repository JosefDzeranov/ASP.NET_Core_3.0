using OnlineShopWebApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShopWebApp.Services
{
    public class OrderBase : IOrderBase
    {
        private static List<Order> Orders { get; set; } = new List<Order>();

        public void Add(Order order)
        {
           Orders.Add(order);
        }

        public List<Order> TryGetAll()
        {
            return Orders;
        }

        public Order TryGetByUserId(string userId)
        {
            return Orders.FirstOrDefault(x => x.UserId == userId);
        }
    }
}
