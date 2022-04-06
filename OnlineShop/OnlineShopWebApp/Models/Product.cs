﻿namespace OnlineShopWebApp.Models
{
    public class Product
    {
        private static int instanceCounter =0;
        public int Id { get; }

        public string Name { get; }

        public decimal Cost { get; }  
        
        public string Description { get; }

        public Product(string name, decimal cost, string description)
        {
            Id = instanceCounter;
            Name = name;
            Cost = cost;
            Description = description;

            instanceCounter+=1;
        }

        public override string ToString()
        {
            return $"Id {this.Id}\nName {this.Name}\nCost {this.Cost}\nDescription {this.Description}\n\n";
        }
    }

    
}
