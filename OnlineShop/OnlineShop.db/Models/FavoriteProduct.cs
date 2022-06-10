using System;
using System.Collections.Generic;

namespace OnlineShop.db.Models
{
    public class FavoriteProduct
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public List<Product> Products { get; set; } = new List<Product>();

    }
}
