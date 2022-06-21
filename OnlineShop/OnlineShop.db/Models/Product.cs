using System.Collections.Generic;

namespace OnlineShop.db.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Cost { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public List<Image> Images { get; set; }
        public Product(int id, string name, decimal cost, string description)
        {
            Id = id;
            Name = name;
            Cost = cost;
            Description = description;
            IsActive = true;
        }
        public Product(string name, decimal cost, string description)
        {
            Name = name;
            Cost = cost;
            Description = description;
        }
        public Product()
        {
            Images = new List<Image>();
        }
    }
}
