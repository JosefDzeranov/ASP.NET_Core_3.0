using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.Db.Models
{
    public class Product
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public decimal Cost { get; set; }

        public string Description { get; set; }

        public List<CartLine> CartLines { get; set; }

        public Product()
        {
            Id = Guid.NewGuid();
            CartLines = new List<CartLine>();
        }


    }
}
