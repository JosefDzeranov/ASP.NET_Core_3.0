using System.Collections.Generic;
using OnlineShopWebApp.Models;
using System.Linq;

namespace OnlineShopWebApp.Services
{
    public class InMemoryOrdersRepository : IOrdersRepository
    {
        private List<Order> orders = new List<Order>();

        public void Add(Order order)
        {
            orders.Add(order);
        }

        public List<Order> GetAll()
        {
            return orders;
        }

        public Order TryGetByUserId(int id)
        {
            return orders.FirstOrDefault(x => x.Id == id);
        }

        public void UpdateStatus(int orderId, OrderStatus newStatus)
        {
            var order = TryGetByUserId(orderId);
            if (order != null)
            {
                order.Status = newStatus;
            }
        }
    }
}
