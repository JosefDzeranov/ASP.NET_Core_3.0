namespace OnlineShop.db.Models
{
    public class OrderStatusUpdatedEventArgs
    {
        public Order Order { get; }
        public OrderStatusUpdatedEventArgs(Order order)
        {
            Order = order;
        }
    }
}
