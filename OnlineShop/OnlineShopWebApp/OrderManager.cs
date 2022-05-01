using Newtonsoft.Json;
using OnlineShopWebApp.Models;
using System;
using System.Collections.Generic;
using System.IO;

namespace OnlineShopWebApp
{
    public class OrderManager : IOrderManager
    {

        string path = @"wwwroot\orders.json";

        public List<Order> OrdersList { get; set; } = new List<Order>();


        public void SaveOrder(Order order)
        {
            OrdersList.Add(order);

            //var jsonData = JsonConvert.SerializeObject(OrdersList);

            //using (StreamWriter sw = new StreamWriter(path, true, System.Text.Encoding.UTF8))
            //{
            //    sw.WriteLine(jsonData);
            //}

        }


        public Order TryGetOrderById(string userId)
        {
            //string data = string.Empty;

            //using (StreamReader sr = new StreamReader(path))
            //{
            //     data = sr.ReadToEnd();
            //}
            //OrdersList = JsonConvert.DeserializeObject<List<Order>>(data);

            return OrdersList.Find(x => x.UserId == userId);
        }

        public Order TryGetOrderById(Guid id)
        {
            //string data = string.Empty;

            //using (StreamReader sr = new StreamReader(path))
            //{
            //     data = sr.ReadToEnd();
            //}
            //OrdersList = JsonConvert.DeserializeObject<List<Order>>(data);

            return OrdersList.Find(x => x.Id == id);
        }

        public List<Order> GetOrders()
        {
            //string data = string.Empty;
            //using (StreamReader sr = new StreamReader(path))
            //{
            //    data = sr.ReadToEnd();
            //}
            //OrdersList = JsonConvert.DeserializeObject<List<Order>>(data);
            return OrdersList;
        }


    }
}