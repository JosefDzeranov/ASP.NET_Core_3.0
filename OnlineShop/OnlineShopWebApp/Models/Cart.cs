using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShopWebApp.Models
{
    public class Cart
    {

        public Guid Id { get; set; }
        public string UserId { get; set; }

        public List<CartItem> Items { get; set; }

        public decimal TotalCost
        {
            get { return Items.Sum(x => x.Cost); }
        }

        public decimal Count
        {
            get { return Items.Sum(x => x.Quantinity); }
        }


    }
}
