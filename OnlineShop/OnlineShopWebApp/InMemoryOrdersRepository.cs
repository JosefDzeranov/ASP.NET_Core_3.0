using OnlineShopWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShopWebApp
{
    public class InMemoryOrdersRepository : IOrdersRepository
    {
        private List<Order> orders = new List<Order>();

        public void Add(Cart cart, User user)
        {
            var newOrder = new Order
            {
                Id = Guid.NewGuid(),
                Cart = cart,
                User = user,
            };

            orders.Add(newOrder);
        }

    }
}
