using System;
using System.Collections.Generic;

namespace OnlineShopWebApp.Models
{
    public class Product
    {
        public int Id { get; }
        public string Name { get; set; }
        public decimal Cost { get; set; }
        public double Square { get; set; }
        public double Width { get; set; }
        public double Length { get; set; }
        public string Description { get; set; }
        public List<string> Images { get; set; }
        public Product(int id, string name, decimal cost, double square, double width, double length, string description, List<string> images)
        {
            Id = id;
            Name = name;
            Cost = cost;
            Square = square;
            Width = width;
            Length = length;
            Description = description;
            Images = images;
        }

    }
}
