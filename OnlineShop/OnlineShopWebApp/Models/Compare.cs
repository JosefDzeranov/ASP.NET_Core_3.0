using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShopWebApp.Models
{
    public class Compare
    {
        public Guid Id { get; set; }
        public Product Product { get; set; }
        public List<CartItem> Items { get; set; }
    }
}
