using Newtonsoft.Json;
using OnlineShopWebApp.Models;
using System.Collections.Generic;
using System.IO;

namespace OnlineShopWebApp
{
    public class OrderManager : IOrderManager
    {

        string path = @"wwwroot\orders.json";

        List<Order> ordersList = new List<Order>();
        public void SaveOrder(Order order)
        {
            ordersList.Add(order);

            var jsonData = JsonConvert.SerializeObject(ordersList);

            using (StreamWriter sw = new StreamWriter(path, true, System.Text.Encoding.UTF8))
            {
                sw.WriteLine(jsonData);
            }


        }


        public Order TryGetOrderById(string userId)
        {
            string data = string.Empty;

            using (StreamReader sr = new StreamReader(path))
            {
                 data = sr.ReadToEnd();
            }
            ordersList = JsonConvert.DeserializeObject<List<Order>>(data);

            return ordersList.Find(x => x.UserId == userId);
        }


    }
}