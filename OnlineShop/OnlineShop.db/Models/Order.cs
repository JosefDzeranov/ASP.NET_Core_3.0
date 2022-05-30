using System.Linq;
using System.Collections.Generic;
using System;

namespace OnlineShop.db.Models
{
    public class Order
    {
        //private static int idSequence = 0;
        public int? Id { get; set; }
        
        public Customer User { get; set; }

        public OrderStatus Status { get; set; }

        public DateTime CreateDateTime { get; set; }

        public List<CartItem> Items { get; set; }
        
        public Order()
        {
            //idSequence = idSequence + 1;
            //Id = idSequence;
            Status = OrderStatus.Created;
            CreateDateTime = DateTime.Now;
            Items = new List<CartItem>();
        }

    }
}
