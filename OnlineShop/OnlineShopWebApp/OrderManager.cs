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

        private List<Order> ordersList = new List<Order>();


        public void SaveOrder(Order order)
        {
            ordersList = GetOrders();
            ordersList.Add(order);

            var jsonData = JsonConvert.SerializeObject(ordersList);

            using (StreamWriter sw = new StreamWriter(path, false, System.Text.Encoding.UTF8))
            {
                sw.WriteLine(jsonData);
            }

        }


        public Order TryGetOrderByUserId(string userId)
        {
            
            ordersList = GetOrders();

            return ordersList.Find(x => x.UserId == userId);
        }

        public Order TryGetOrderById(Guid id)
        {
            
            ordersList = GetOrders();

            return ordersList.Find(x => x.Id == id);
        }

        public List<Order> GetOrders()
        {
            string data = string.Empty;
            if (File.Exists(path))
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    data = sr.ReadToEnd();
                }
                ordersList = JsonConvert.DeserializeObject<List<Order>>(data);
            }
            else
            {
                ordersList = new List<Order>();
            }
            
            return ordersList;
        }

        public void UpdateStatus(Guid id, OrderStatus status)
        {
           
            var order = TryGetOrderById(id);
            
          
            if (order != null)
            {
              
                order.Status = status;

            }
            var jsonData = JsonConvert.SerializeObject(ordersList);

            using (StreamWriter sw = new StreamWriter(path, false, System.Text.Encoding.UTF8))
            {
                sw.WriteLine(jsonData);
            }

        }
    }
}