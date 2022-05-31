using System;
using System.Collections.Generic;

namespace OnlineShop.DB.Models
{
    public class Cart
    {
        public Guid Id { get; set; }
        public int UserId { get; set; }
        public List<CartItem> Items { get; set; }
        //public Order? Order { get; set; }
    }
}
