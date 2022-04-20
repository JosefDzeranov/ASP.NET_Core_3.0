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

        public void Add(Cart cart, Order order)
        {
            var newOrder = new Order
            {
                Id = Guid.NewGuid(),
                UserId = Constants.UserId,
                Cart = cart,
                Name = order.Name,
                Adress = order.Adress,
                Phone = order.Phone,
            };

            orders.Add(newOrder);
        }

    }
}
