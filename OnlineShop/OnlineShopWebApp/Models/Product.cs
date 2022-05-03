using System;
using System.ComponentModel.DataAnnotations;

namespace OnlineShopWebApp.Models
{
    public class Product
    {
        public Guid Id { get; set; }

        [Required]
        public string ImagePath { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public decimal Cost { get; set; }

        [Required]
        public string Description { get; set; }

        public Product () { } // Empty ctor for XML serializing.
        
        public Product(Guid id, string imagePath, string name, decimal cost, string description)
        {
            Id = id;
            ImagePath = imagePath;
            Name = name;
            Cost = cost;
            Description = description;
        }
    }
}
