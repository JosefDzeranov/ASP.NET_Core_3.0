using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShopWebApp.Models
{
    public class CartViewModel
    {

        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public List<CartItemViewModel> Items { get; set; }

        public decimal TotalCost
        {
            get { return Items.Sum(x => x.Cost); }
        }
        public int Count
        {
            get { return Items.Sum(x => x.Quantinity); }
        }


    }
}
