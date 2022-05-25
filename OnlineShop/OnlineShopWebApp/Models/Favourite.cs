using System;
using System.Collections.Generic;

namespace OnlineShopWebApp.Models
{
    public class Favourite
    {
        public Guid Id { get; set; }
        public string UserId { get; set; }
        public List<Product> Products { get; set; }
        public Favourite() { }
        public Favourite(string userId)
        {
            Id = Guid.NewGuid();
            UserId = userId;
            Products = new List<Product>();
        }
    }
}
