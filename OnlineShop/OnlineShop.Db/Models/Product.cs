using System;
using System.Collections.Generic;

namespace OnlineShop.Db.Models
{
    public class Product
    {
        public Guid Id { get; set; }

        public List<Image> Images { get; set; }

        public string Name { get; set; }

        public decimal Cost { get; set; }

        public string Description { get; set; }

        public List<BasketItem> BasketItems { get; set; }

        public bool Available { get; set; }

        public  Product ()
        {
            BasketItems = new List<BasketItem>();
            Images = new List<Image>();
        }

        public Product(Guid id, string name, decimal cost, string description)
        {
            Id = id;
            Name = name;
            Cost = cost;
            Description = description;
            Available = true;
        }
    }
}
