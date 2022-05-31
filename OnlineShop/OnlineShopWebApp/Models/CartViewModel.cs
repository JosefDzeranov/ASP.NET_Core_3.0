using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShopWebApp.Models
{
    public class CartViewModel
    {
        public Guid Id { get; set; }
        public int UserId { get; set; }
        public List<CartItemViewModel> Items { get; set; }

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
