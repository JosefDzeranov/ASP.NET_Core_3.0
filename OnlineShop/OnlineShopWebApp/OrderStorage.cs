using System;
using OnlineShopWebApp.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShopWebApp
{
    public class OrderStorage
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

        public void AddOrder(string userId, Basket basket, Delivery delivery)
        {
            var order = orders.FirstOrDefault(item => item.UserId == userId);


        }
    }
}
