using System;
using System.Collections.Generic;

namespace OnlineShop.DB.Models
{
    public class Product
    {
        public Guid Id { get; set; }   
        public string Name { get; set; }
        public decimal Cost { get; set; }
        public string Description { get; set; }
        public virtual List<Image> Images { get; set; } = new List<Image>();
       
    }

}



