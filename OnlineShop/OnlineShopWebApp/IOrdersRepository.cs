using OnlineShopWebApp.Models;
using System.Collections.Generic;

namespace OnlineShopWebApp
{
    public interface IOrdersRepository
    {
        void AddCart(Cart cart);
        void SaveOrderInformation(Order order);
        public List<Order> GetOrdersInformation();
    }
}