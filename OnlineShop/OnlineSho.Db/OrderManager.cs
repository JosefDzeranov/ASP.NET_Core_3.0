using Microsoft.EntityFrameworkCore;
using OnlineShop.Db.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShop.Db
{
    public class OrderManager : IOrderManager
    {

        private readonly DataBaseContext dataBaseContext;
        public OrderManager(DataBaseContext dataBaseContext)
        {
            this.dataBaseContext = dataBaseContext;
        }

        //string path = @"wwwroot\orders.json";

        //private List<Order> ordersList = new List<Order>();


        public void SaveOrder(Order order)
        {
            var ordersList = GetOrders();
            dataBaseContext.Orders.Add(order);
            
            dataBaseContext.SaveChanges();

            //var jsonData = JsonConvert.SerializeObject(ordersList);

            //using (StreamWriter sw = new StreamWriter(path, false, System.Text.Encoding.UTF8))
            //{
            //    sw.WriteLine(jsonData);
            //}

        }


        public Order TryGetOrderByUserId(string userId)
        {

            return dataBaseContext.Orders.Include(x => x.Cart).ThenInclude(x => x.CartLines).Include(x => x.OrderDate).FirstOrDefault(x => x.UserId == userId);
        }

        public Order TryGetOrderById(Guid id)
        {

            var ordersList = GetOrders();

            return ordersList.Find(x => x.Id == id);
        }

        public List<Order> GetOrders()
        {
            //string data = string.Empty;
            //if (File.Exists(path))
            //{
            //    using (StreamReader sr = new StreamReader(path))
            //    {
            //        data = sr.ReadToEnd();
            //    }
            //    ordersList = JsonConvert.DeserializeObject<List<Order>>(data);
            //}
            //else
            //{
            //    ordersList = new List<Order>();
            //}

            return dataBaseContext.Orders.Include(x => x.Cart).Include(x => x.OrderData).ToList();
        }

        public void UpdateStatus(Guid id, OrderStatus status)
        {

            var order = TryGetOrderById(id);


            if (order != null)
            {

                order.Status = status;

            }
            dataBaseContext.SaveChanges();
            //var jsonData = JsonConvert.SerializeObject(ordersList);

            //using (StreamWriter sw = new StreamWriter(path, false, System.Text.Encoding.UTF8))
            //{
            //    sw.WriteLine(jsonData);
            //}

        }
    }
}