using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.Db.Models
{
    public class Favourite
    {
        public Guid FavouriteId { get; set; }
        public string UserId { get; set; }
        public ICollection<Product> Products { get; set; }
        public List<FavouriteProducts> FavouriteProducts { get; set; } = new List<FavouriteProducts>();

        public Favourite()
        {
            Products = new List<Product>();
        }
    }
}
