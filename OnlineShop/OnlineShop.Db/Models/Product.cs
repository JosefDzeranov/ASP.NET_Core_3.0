using System;
using System.Collections.Generic;

namespace OnlineShop.Db.Models
{
    public class Product
    {
        public Guid Id { get; set;}
        public string Name { get; set;}
        public decimal Cost { get; set;}
        public string Description { get; set;}
        public string ImagePath { get; set;}
        public List<CartItem> CartItems { get; set; }
        public Product()
        {
            //Id = new Guid(); <= does not help
            CartItems = new List<CartItem>();
        }
        public Product(string name, decimal cost, string description, string imagePath)
        {
            //Id = new Guid(); <= does not help
            Name = name;
            Cost = cost;
            Description = description;
            ImagePath = imagePath;
        }
    }
}
