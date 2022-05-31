using System.Collections.Generic;

namespace OnlineShop.db.Models
{
    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Cost { get; set; }

        public string Description { get; set; }

        public string ImagePath { get; set; }

        public bool IsActive { get; set; }
    }
}
