using System;

namespace OnlineShop.Db.Models
{
    public class CartItem
    {
        public Guid Id { get; set; }
        public Product Product { get; set; }
        public int Count { get; set; }
        public Guid Cart { get; set; }

        public decimal Cost
        {
            get
            {
                return Cost;
            }
            set
            {
                Cost = Product.Cost * Count;
            }
        }
    }
}
