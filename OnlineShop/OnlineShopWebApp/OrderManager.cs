using Newtonsoft.Json;
using OnlineShopWebApp.Models;
using System.Collections.Generic;
using System.IO;

namespace OnlineShopWebApp
{
    public class OrderManager : IOrderManager
    {

        List<Order> ordersList = new List<Order>();
        public void SaveOrder(Order order)
        {
            ordersList.Add(order);

        }

        public Order TryGetOrderById(string userId)
        {
            return ordersList.Find(x => x.UserId == userId);
        }

    }
}