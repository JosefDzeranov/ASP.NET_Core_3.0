using Newtonsoft.Json;
using OnlineShopWebApp.Models;
using System.Collections.Generic;

namespace OnlineShopWebApp
{
    public class OrdersRepositoryJSON: IOrdersRepository
    {
        private const string fileName  = "order.json";
       
        private readonly List<Order> orders;

        public OrdersRepositoryJSON()
        {
            orders = GetAll();
        }
                
        public void Create(Order order)
        {
            orders.Add(order);
            var jsonData = JsonConvert.SerializeObject(orders, Formatting.Indented);
            FileProvider.Write(fileName, jsonData);
        }

        public List<Order> GetAll()
        {
            return orders;
        }
    }
}
