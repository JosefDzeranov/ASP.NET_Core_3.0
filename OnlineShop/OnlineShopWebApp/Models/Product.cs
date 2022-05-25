using System;

namespace OnlineShopWebApp.Models
{
    public class Product
    {
        private static int uniId = 1;
        public int Id { get; }
        public string Name { get; }
        public decimal Price { get; }
        public string Description { get; }
        public string ImagesPath { get; }

        public Product(string name, decimal price, string description, string imagespath = null)
        {
            Id = uniId;
            Name = name;
            Price = price;
            Description = description;

            uniId += 1;
            ImagesPath = imagespath;
        }

        public override string ToString()
        {
            return $"{Id}\n{Name}\n{Price}";
        }
    }
}
