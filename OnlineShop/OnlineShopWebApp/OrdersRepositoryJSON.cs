using Newtonsoft.Json;
using OnlineShopWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShopWebApp
{
    public class OrdersRepositoryJSON: IOrdersRepository
    {
        public static string Path { get; } = $"order.json";

        private List<Cart> orders = new List<Cart>();

        public void AddCart(Cart cart)
        {
            orders.Add(cart);
        }

        public void SaveOrderInformation(Order order)
        {
            var jsonData = JsonConvert.SerializeObject(order.ToString());
            FileProvider.Append(Path, jsonData);
        }

        public List<Order> TryGetOrdersInformation()
        {
            var fileData = FileProvider.Get(Path);
            var orderResults = JsonConvert.DeserializeObject<List<Order>>(fileData);
            return orderResults;
        }
    }
}
