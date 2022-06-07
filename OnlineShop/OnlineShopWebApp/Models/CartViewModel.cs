using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShopWebApp.Models
{
    public class CartViewModel
    {

        public List<CartLineViewModel> CartLines = new List<CartLineViewModel>();
        public Guid Id { get; set; }
        public static int IdCounter = 0;
        public string UserId { get; set; }

        public decimal CartCost
        {
            get
            {
                decimal Cost = 0;

                Cost = CartLines?.Sum(x => x.Cost) ?? 0;
                return Cost;
            }
        }

        public decimal Amount
        {
            get
            {
                decimal Amount = 0;

                Amount = CartLines?.Sum(x => x.Amount) ?? 0;
                return Amount;
            }
        }


        
    }
}

