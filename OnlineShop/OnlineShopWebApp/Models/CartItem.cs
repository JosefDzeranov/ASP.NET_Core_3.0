using OnlineShopWebApp.Models;
using System;

namespace OnlineShopWebApp
{
    public class CartItem
    {
        public Guid Id { get; set; }
        public ProductViewModel Product { get; set; }
        public int Amount { get; set; }
        public decimal Cost 
        { 
            get
            {
                return Product.Cost * Amount;
            }
        }

    }
}
