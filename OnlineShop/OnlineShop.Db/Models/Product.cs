using System;

namespace OnlineShop.Db.Models
{
    public class Product
    {
        public Guid Id { get; set; }

        public string CodeNumber { get; set; }

        public decimal Cost { get; set; }

        public double Square { get; set; }

        public double Width { get; set; }
        
        public double Length { get; set; }
        
        public string Description { get; set; }
        
        public string Images { get; set; }

        
    }
}
