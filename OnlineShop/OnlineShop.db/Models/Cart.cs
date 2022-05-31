using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace OnlineShop.db.Models
{
    public class Cart
    {
        public int Id { get; set; }

        public string UserId { get; set; }

        public List<CartItem> Items { get; set; }

        public DateTime CreatedDateTime { get; set; }

        public Cart()
        {
            CreatedDateTime= DateTime.Now;
            Items = new List<CartItem>();
        }

    }
}
