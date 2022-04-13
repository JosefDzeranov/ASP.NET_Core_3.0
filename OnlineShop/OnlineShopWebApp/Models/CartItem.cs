using OnlineShopWebApp.Models;
using System;

namespace OnlineShopWebApp
{
    public class CartItem
    {
        public Guid Id { get; set; }
        public Product Product { get; set; }
        public int Amout { get; set; }
        public decimal Average
        {
            get
            {
                return Product.Price * Amout;
            }
        }
    }
}
