using System.IO;
using OnlineShopWebApp.Models;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;

namespace OnlineShopWebApp
{
    public class OrderStorage: IOrderStorage
    {
        private List<Order> orders = new List<Order>();
        public List<Order> Orders
        {
            get
            {
                return orders;
            }
        }

        public Order TryGetByUserId(string userId)
        {
            return orders.FirstOrDefault(order => order.UserId == userId);
        }

        public void AddOrder(string userId, Basket basket)
        {
            var order = TryGetByUserId(userId);
            if (order == null)
            {
                var newOrder = new Order(userId, basket);
                orders.Add(newOrder);
            }
        }

        public void SaveOrderToXmlFile(Order order)
        {
            var xmlSerializer = new XmlSerializer(typeof(Order));
            using (FileStream fs = new FileStream("Data/Orders/order.xml", FileMode.OpenOrCreate))
            {
                xmlSerializer.Serialize(fs, order);
            }

        }
    }
}
