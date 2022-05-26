using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.Db.Models
{
    public class FavouriteProducts
    {
        public Guid Id { get; set; }
        public Guid FavouriteId { get; set; }
        public Favourite Favourite { get; set; }
        public Guid ProductId { get; set; }
        public Product Product { get; set; }
    }
}
