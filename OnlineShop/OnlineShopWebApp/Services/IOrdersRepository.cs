using OnlineShopWebApp.Models; 
namespace OnlineShopWebApp.Services
{
    public interface IOrdersRepository
    {
        void Add(Order order);
    }
}