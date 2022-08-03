using System;
using System.Collections.Generic;
using System.Linq;

namespace ViewModels
{
    public class CartViewModel
    {
        public Guid Id { get; set; }
        public string UserId { get; set; }
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
