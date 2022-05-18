using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.DB.Models
{
    public class OrderItem
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public virtual Product Product { get; set; }
        public int Quantinity { get; set; }
        public Guid OrderId { get; set; }
        public virtual Order Order { get; set; }
    }
}
