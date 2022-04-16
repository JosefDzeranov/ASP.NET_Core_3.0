using Newtonsoft.Json;
using OnlineShopWebApp.Models;
using System.Collections.Generic;
using System.IO;

namespace OnlineShopWebApp
{
    public class OrderManagerJson : IOrderManager
    {
        
        string path = @"G:\VSrepos\ASP.NET_Core_3.0.git\OnlineShop\OnlineShopWebApp\wwwroot\orders.json";

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