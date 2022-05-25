using System;

namespace OnlineShop.DB.Models
{
    public class CartItem
    {
        public Guid Id { get; set; }
        public virtual Product Product { get; set; }
        public int Quantinity { get; set; }
      
      
    }
}
