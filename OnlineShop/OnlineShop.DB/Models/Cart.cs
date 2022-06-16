using System;
using System.Collections.Generic;

namespace OnlineShop.DB.Models
{
    public class Cart
    {
        public Guid Id { get; set; }
        public string UserId { get; set; }
        public virtual List<CartItem> Items { get; set; } = new List<CartItem>();
    }
}
