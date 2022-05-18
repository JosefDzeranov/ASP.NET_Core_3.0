using System;
using System.Collections.Generic;

namespace OnlineShop.Db.Models
{
    public class Basket
    {
        public Guid Id { get; set; }
        public string UserId { get; set; }
        public List<BasketItem> Items { get; set; }
    }
}
