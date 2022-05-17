using System;
using System.Collections.Generic;
using OnlineShop.Db.Models;

namespace OnlineShopWebApp.Models
{
    public class Favorites
    {
        public Guid Id { get; set; }
        public string UserId { get; set; }
        public List<Product> Products { get; set; }

        public Favorites() { } // Empty ctor for XML serializing.
        public Favorites(string userId)
        {
            Id = Guid.NewGuid();
            UserId = userId;
            Products = new List<Product>();
        }
    }
}
