using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Db.Models
{
    public class Product
    {
        [Key]
        public Guid Id { get; set; }

        public string Name { get; set; }

        //[Column(TypeName = "decimal(18, 2)")]
        public decimal Cost { get; set; }

        public string Description { get; set; }

        public string ImagePath { get; set; }

        public List<CartItem> CartItems { get; set; }

        public bool Available { get; set; }

        public Product()
        {
            CartItems = new List<CartItem>();
        }

        public Product(string name, decimal cost, string description, string imagePath)
        {
            Id = Guid.NewGuid();
            ImagePath = imagePath;
            Name = name;
            Cost = cost;
            Description = description;
            Available = true;
            CartItems = new List<CartItem>();
        }
    }
}