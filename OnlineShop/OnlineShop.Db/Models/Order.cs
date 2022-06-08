using System;
using System.Collections.Generic;

namespace OnlineShop.Db.Models
{
    public class Order
    {
        public Guid Id { get; set; }
        public DeliveryInformation DeliveryInformation { get; set; }        
        public OrderState State { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public List<CartItem> Items { get; set; }
        public Order()
        {
            Items = new List<CartItem>();
        }
    }
}
