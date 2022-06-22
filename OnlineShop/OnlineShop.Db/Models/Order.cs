using System;
using System.Collections.Generic;

namespace OnlineShop.Db.Models
{
    public class Order
    {
        public Guid Id { get; set; }

        public string UserId { get; set; }

        public DateTime Date { get; set; }

        public OrderState State { get; set; }

        public List<CartItem> Items { get; set; }

        public UserDeliveryInfo DeliveryInfo { get; set; }

        public Order()
        {
            Date = DateTime.Now;

            State = OrderState.Created;

            Items = new List<CartItem>();
        }
    }
}