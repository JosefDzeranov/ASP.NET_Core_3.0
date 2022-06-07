using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.Db.Models
{
    public class Favorite
    {

        public Guid Id { get; set; }

        public List<Product> Products { get; set; } 
        public string UserId { get; set; }

        public Favorite()
        {
            Products = new List<Product>();
        }
    }
}
