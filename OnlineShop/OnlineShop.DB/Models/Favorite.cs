
using System;
using System.Collections.Generic;

namespace OnlineShop.DB.Models
{
    public class Favorite
    {
        public Guid Id { get; set; }
        public string UserId { get; set; }
        public virtual List<Product> Products { get; set; } = new List<Product>();
    }
}
