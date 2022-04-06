using OnlineShopWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShopWebApp
{
    public class OrderReposititory:ProductReposititory
    {
        private static List<Order> order = new List<Order>()
        {
            new Order("Name1", 10, "Discription"),
            new Order("Name2", 20, "Discription"),
            
        };
    }
}
