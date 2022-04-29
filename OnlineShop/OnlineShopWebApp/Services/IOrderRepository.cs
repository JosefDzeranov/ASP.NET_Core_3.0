using OnlineShopWebApp.Models;

namespace OnlineShopWebApp
{
    public interface IOrderRepository
    {
        void Add(Order order);
    }
}