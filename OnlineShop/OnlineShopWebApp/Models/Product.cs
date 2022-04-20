﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShopWebApp.Models
{
    public class Product
    {
        private static int constantCounter = 0;
        public int Id { get; }
        public string Name { get; set; }
        public decimal Cost { get; set; }
        public string Description { get; set; }
        public int Pages { get; set; }


        public Product(string name, decimal cost, string description, int pages)
        {
            Id = constantCounter;
            Name = name;
            Cost = cost;
            Description = description;
            Pages = pages;
            constantCounter++;
        }

        public override string ToString()
        {
            return $"{Id}\n{Name}\n{Cost}";
        }
    }
}
