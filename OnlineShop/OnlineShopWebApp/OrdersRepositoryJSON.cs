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
        public static string Path { get; } = "order.json";
        public static List<Order> orders = new List<Order>();

        private List<Cart> carts = new List<Cart>();

        public void AddCart(Cart cart)
        {
            carts.Add(cart);
        }

        public void SaveOrderInformation(Order order)
        {
            orders.Add(order);
            var jsonData = JsonConvert.SerializeObject(orders, Formatting.Indented);
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
