using OnlineShopWebApp.Models;
using System.Collections.Generic;
namespace OnlineShopWebApp.Services
{
    public interface IOrdersRepository
    {
        void Add(Order order);

        List<Order> GetAll();
        Order TryGetByUserId(int id);

        void UpdateStatus(int orderId, OrderStatus newStatus);
    }
}