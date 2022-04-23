using System.Collections.Generic;

namespace OnlineDesignBureauWebApp.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Cost { get; set; }
        public double Square { get; set; }
        public double Width { get; set; }
        public double Length { get; set; }
        public string Description { get; set; }
        public List<string> Images { get; set; }
    }
}
