using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShop.DB.Models
{
    public class Cart
    {
        public Guid Id { get; set; }
        public int UserId { get; set; }
        public List<CartItem> Items { get; set; }
        public bool IsDeleted { get; set; }
        public int Amount
        {
            get { return Items?.Sum(x => x.Amount) ?? 0; }
        }
    }
}
