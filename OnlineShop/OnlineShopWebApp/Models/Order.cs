using System;

namespace OnlineShopWebApp.Models
{
    public class Order
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public string UserId { get; set; }
        public Basket Basket { get; set; }
        public Delivery Delivery { get; set; }

        public Order () { }
        public Order(string userId, Basket basket, Delivery delivery)
        {
            Id = Guid.NewGuid();
            Date = DateTime.Now;
            UserId = userId;
            Basket = basket;
            Delivery = delivery;
        }
    }
}
