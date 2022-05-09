using System;

namespace OnlineShopWebApp.Models
{
    public class Order
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public string UserId { get; set; }
        public OrderStatus Status { get; set; }
        public Basket Basket { get; set; }
        public Delivery Delivery { get; set; }

        public Order () { } // Empty ctor for XML serializing.
        public Order(string userId, Basket basket, Delivery delivery)
        {
            Id = Guid.NewGuid();
            Date = DateTime.Now;
            UserId = userId;
            Status = OrderStatus.Created;
            Basket = basket;
            Delivery = delivery;
        }
    }
}
