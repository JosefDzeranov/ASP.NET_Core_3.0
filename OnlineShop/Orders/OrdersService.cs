using OnlineShop.db;
using OnlineShop.db.Models;

namespace Orders
{
    public class OrdersService
    {
        private readonly IOrdersRepository ordersRepository;

        public OrdersService(IOrdersRepository ordersRepository)
        {
            this.ordersRepository = ordersRepository;
        }

        public static event EventHandler<OrderStatusUpdatedEventArgs> OrderStatusUpdatedEvent;

        public void Add(Order order)
        {
            ordersRepository.Add(order);
        }

        public List<Order> GetAll()
        {
            return ordersRepository.GetAll();
        }

        public Order TryGetById(int id)
        {
            return ordersRepository.TryGetById(id);
        }

        public List<Order> TryGetByUserId(string userId)
        {
            return ordersRepository.TryGetByUserId(userId);
        }

        public void UpdateStatus(int orderId, OrderStatus newStatus)
        {
            ordersRepository.UpdateStatus(orderId, newStatus);
            
            var order = TryGetById(orderId);
            OrderStatusUpdatedEvent?.Invoke(this, new OrderStatusUpdatedEventArgs(order));
        }
    }
}