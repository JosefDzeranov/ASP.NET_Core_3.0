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

        public List<Order> GetAll()
        {
            return orders;
        }

        public Order TryGetById(Guid id)
        {
            return orders.FirstOrDefault(x => x.Id == id);
        }
        public void Add(Cart cart, User user)
        {
            var newOrder = new Order
            {
                Id = new Guid(),
                Cart = cart,
                User = user,
                State = "Создан",
                Date = DateTime.Now.ToString("dd MMMM yyyy"),
                Time = DateTime.Now.ToString("HH:mm:ss")
            };

            orders.Add(newOrder);
        }

    }
}
