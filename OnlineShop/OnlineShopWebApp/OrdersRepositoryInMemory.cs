using OnlineShopWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShopWebApp
{
    public class OrdersRepositoryInMemory
    {
        private List<Cart> orders = new List<Cart>();

        public void AddCart(Cart cart)
        {
            orders.Add(cart);
        }
        


    }
}
