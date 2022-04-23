namespace OnlineShopWebApp.Models
{
    public interface IOrdersStorage
    {
        void Add(Order order);
    }
}