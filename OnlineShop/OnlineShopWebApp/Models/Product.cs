﻿namespace OnlineShopWebApp.Models
{
    public class Product
    {
        private static int counter = 1;
        public int Id { get;}
        public string Name { get;}
        public decimal Cost { get;}
        public string Description { get;}
        public Product(string name, int cost, string description)
        {
            Id = counter;
            Name = name;
            Cost = cost;
            Description = description;
            counter += 1;
        }

        public override string ToString()
        {
            return $"{Id}\n{Name}\n{Cost}";
        }
    }
}
