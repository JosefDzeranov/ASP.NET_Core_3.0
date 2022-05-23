using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShopWebApp
{
    public class Cart
    {
        public Guid Id { get; set; }
        public string UserId { get; set; }
        public List<CartItem> Items { get; set; }

        public decimal Cost
        {
            get
            {
                return Items?.Sum(x => x.Cost) ?? 0;
            }
        }

        public decimal Amout
        {
            get
            {
                return Items?.Sum(x => x.Amout) ?? 0;
            }
        }
    }
}
