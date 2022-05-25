using System;
using System.Collections.Generic;

namespace OnlineShopWebApp.Models
{
    public class Compare
    {
        public Guid Id { get; set; }
        public string UserId { get; set; }    
        public List<Product> Products { get; set; }
        public Compare() { }
        public Compare(string userId)
        {
            Id = Guid.NewGuid();
            UserId = userId;
            Products = new List<Product>();
        }
    }
}
