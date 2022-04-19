using System.Collections.Generic;
using OnlineShopWebApp.Models;
using OnlineShopWebApp.Views;
using OnlineShopWebApp.Services; 

namespace OnlineShopWebApp.Services
{
    public class InMemoryOrdersRepository : IOrdersRepository

    {
        private List<Order> orders = new List<Order>();

        public void Add(Order order)
        {
            orders.Add(order); 
        }
       
    }
}
