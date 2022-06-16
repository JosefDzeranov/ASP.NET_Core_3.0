using System;
using System.Collections.Generic;

namespace OnlineShop.Db.Models
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Cost { get; set; }
        public string Description { get; set; }
        public int Pages { get; set; }
        //public string ImagePath { get; set; }
        public List<CartItem> CartItems { get; set; }
        public List<Image> Images { get; set; }

        public Product()
        {
            CartItems = new List<CartItem>();
            Images = new List<Image>();
        }
    }
}
