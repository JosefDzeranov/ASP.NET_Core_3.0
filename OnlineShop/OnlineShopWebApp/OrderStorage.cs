using System;
using System.IO;
using OnlineShopWebApp.Models;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;
using System.Xml.Linq;

namespace OnlineShopWebApp
{
    public class OrderStorage : IOrderStorage
    {
        private List<Order> _orders = new List<Order>();

        public Order TryGetById(Guid id)
        {
            var order = _orders.FirstOrDefault(order => order.Id == id);
            return order;
        }

        public void Add(string userId, Basket basket, Delivery delivery)
        {
            var newOrder = new Order(userId, basket, delivery);
            _orders.Add(newOrder);

            var xmlSerializer = new XmlSerializer(typeof(List<Order>));
            using (FileStream fs = new FileStream("Data/Orders.xml", FileMode.OpenOrCreate))
            {
                xmlSerializer.Serialize(fs, _orders);
            }
        }

        public List<Order> GetOrderData()
        {
            var xmlSerializer = new XmlSerializer(typeof(List<Order>));
            using (FileStream fs = new FileStream("Data/Orders.xml", FileMode.OpenOrCreate))
            {
                _orders = xmlSerializer.Deserialize(fs) as List<Order>;
            }
            return _orders;
        }

        public void UpdateStatus(Guid id, OrderStatus newStatus)
        {
            var xDoc = XDocument.Load("Data/Orders.xml");
            var updateOrder = xDoc.Element("ArrayOfOrder")
                              .Elements("Order")
                              .FirstOrDefault(order => Guid.Parse(order.Element("Id").Value) == id);

            var orderStatus = updateOrder.Element("Status");
            orderStatus.Value = newStatus.ToString();

            xDoc.Save("Data/Orders.xml");
        }
    }
}
