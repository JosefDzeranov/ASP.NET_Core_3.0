using OnlineShopWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShopWebApp
{
    public class Order: Product
    {
        public Order(string name, decimal cost, string description) :base(name,cost,description)
        {
            var orderItem = new Product(Name,Cost,Description);
           
        }

    }
}
