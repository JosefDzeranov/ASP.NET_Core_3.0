using System.Collections.Generic;

namespace OnlineShop.db.Models
{
    public class Product
    {
        public Product(int id, string name, decimal cost, string description, string imagePath)
        {
            Id = id;
            Name = name;
            Cost = cost;
            Description = description;
            ImagePath = imagePath;
            IsActive = true;
        }

        public Product(string name, decimal cost, string description, string imagePath)
        {
            Name = name;
            Cost = cost;
            Description = description;
            ImagePath = imagePath;
        }

        public Product(string name, decimal cost, string description)
        {
            Name = name;
            Cost = cost;
            Description = description;
        }

        public Product()
        {

        }

        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Cost { get; set; }

        public string Description { get; set; }

        public string ImagePath { get; set; }

        public bool IsActive { get; set; }
    }
}
