using System.Collections.Generic;

namespace OnlineShop.Db.Models
{
    public class CartItem
    {
        public Product Product { get; set; }
        public int Count { get; set; }
        public List<AdditionalOptions> additionalOptions { get; set; } = new List<AdditionalOptions> { };

    }
}
