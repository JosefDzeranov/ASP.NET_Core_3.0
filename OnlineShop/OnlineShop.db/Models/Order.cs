using System.Linq;
using System.Collections.Generic;
using System;

namespace OnlineShop.db.Models
{
    public class Order
    {
        public int? Id { get; set; }
        
        public User User { get; set; }

        public OrderStatus Status { get; set; }

        public DateTime CreateDateTime { get; set; }

        public List<CartItem> Items { get; set; }
        
        public Order()
        {
            Status = OrderStatus.Created;
            CreateDateTime = DateTime.Now;
            Items = new List<CartItem>();
        }

    }
}
