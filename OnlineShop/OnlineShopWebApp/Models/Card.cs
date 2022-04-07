using OnlineShopWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShopWebApp
{
    public class Card
    {
        private static int inctanceCounter = 0;

        public int Id { get; }
        public string Name { get; }
        public decimal Cost { get; }
        public string Description { get; }

        public Card(Product product)
        {
            Id = product.Id;
            Name = product.Name;
            Cost = product.Cost;
            Description = product.Description;
        }

        public override string ToString()
        {
            return $"{Id}\n{Name}\n{Cost}";
        }

    }
}
