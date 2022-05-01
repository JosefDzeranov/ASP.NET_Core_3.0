using OnlineShopWebApp.Models;
using System.Collections.Generic;

namespace OnlineShopWebApp
{
    public interface IOrderManager
    {
        public List<Order> OrdersList { get; set; }
        public List<Order> GetOrders();
        public void SaveOrder(Order order);
        public Order TryGetOrderById(string userId);
    }
}