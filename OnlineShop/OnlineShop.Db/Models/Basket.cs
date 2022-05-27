using System;
using System.Collections.Generic;

namespace OnlineShop.Db.Models
{
    public class Basket
    {
        public Guid Id { get; set; }
        public string UserId { get; set; }
        public List<BasketItem> Items { get; set; }

        public DateTime CreationDateTime { get; set; }

        public Basket()
        {
            Items = new List<BasketItem>();
            CreationDateTime = DateTime.Now;
        }
    }
}
