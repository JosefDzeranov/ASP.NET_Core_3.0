using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShopWebApp.Models
{
    public class Cart
    {
        public Guid Id { get; set; }
        public int UserId { get; set; }
        public List<CartItem> Items { get; set; }

        public decimal Cost
        {
            get { return Items?.Sum(x => x.Cost) ?? 0; }
        }

        public int Amount
        {
            get { return Items?.Sum(x => x.Amount) ?? 0; }
        }
    }
}
