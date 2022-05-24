using System;
using System.Collections.Generic;

namespace OnlineShop.Db.Models
{
    public class Order
    {
        public Guid Id { get; set; }
        public string UserId { get; set; }       
        public DateTime Date { get; set; }
        public OrderStatus Status { get; set; }
        public List<BasketItem> Items { get; set; }
        public DeliveryInfo DeliveryInfo { get; set; }

        public Order()
        {
            Date = DateTime.Now;
            Status = OrderStatus.Created;
            Items = new List<BasketItem>();
        }
    }
}
