using Newtonsoft.Json;
using OnlineShopWebApp.Models;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Unicode;

namespace OnlineShopWebApp
{
    public class OrdersInMemoryRepository : IOrderBase
    {
        private List<Order> orders = new List<Order>();

        System.Text.Json.JsonSerializerOptions jsonOption = new System.Text.Json.JsonSerializerOptions()
        {
            Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
            WriteIndented = true
        };

        public int NextOrderId()
        {
            var allOrders = AllOrders();

            if(allOrders.Any())
            {
                return allOrders.Select(x => x.Id).Max() + 1;
            }
            else
            {
                return 1;
            }
        }

        public IEnumerable<Order> AllOrders()
        {
            using (StreamReader r = new StreamReader("Models/Orders.json", Encoding.UTF8))
            {
                return JsonConvert.DeserializeObject<List<Order>>(r.ReadToEnd());
            }
        }

        public void UpdateOrderStatus(int orderId, OrderStatus status)
        {
            var allOrders = AllOrders();
            var necessaryOrder = allOrders.FirstOrDefault(x => x.Id == orderId);
            necessaryOrder.Status = status;
            var json = System.Text.Json.JsonSerializer.Serialize(allOrders, jsonOption);
            File.WriteAllText("Models/Orders.json", json);
        }

        public void Add(Order order)
        {
            order.Id = NextOrderId();
            var newListOfOrders = AllOrders().Append(order);
            var json = System.Text.Json.JsonSerializer.Serialize(newListOfOrders, jsonOption);
            File.WriteAllText("Models/Orders.json", json);
        }
    }
}
