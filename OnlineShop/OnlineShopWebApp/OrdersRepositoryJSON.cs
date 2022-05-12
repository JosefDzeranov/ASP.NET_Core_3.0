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
            orders = GetAllFromFile();
        }
                
        public void Create(Order order)
        {
            orders.Add(order);
            var jsonData = JsonConvert.SerializeObject(orders, Formatting.Indented);
            FileProvider.Write(fileName, jsonData);
        }
        public List<Order> GetAllFromFile()
        {
            var fileData = FileProvider.Get(fileName);
            var orderResults = JsonConvert.DeserializeObject<List<Order>>(fileData);
            return orderResults; 
        }
    }
}
