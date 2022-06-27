using System;
using System.Collections.Generic;

namespace OnlineShop.Db.Models
{
    public class Cart
    {
        public Guid Id { get; set; }
        public string BuyerLogin { get; set; }

        public List<CartItem> CartItems { get; set; }

        public UserDeleveryInfo UserDeleveryInfo { get; set; }

        public DateTime CreateDateTime { get; set; }

        public Cart()
        {
            CartItems = new List<CartItem>();
            CreateDateTime = DateTime.Now;
        }
    }
}
