using System;
using System.Collections.Generic;


namespace OnlineShop.db.Models
{
    public class Cart
    {
        public int Id { get; set; }

        public string UserId { get; set; }

        public List<CartItem> Items { get; set; } = new List<CartItem>();

        public DateTime CreatedDateTime { get; set; }
    }
}
