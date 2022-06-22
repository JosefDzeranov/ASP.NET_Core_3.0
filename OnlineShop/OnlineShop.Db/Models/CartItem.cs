using System;
using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Db.Models
{
    public class CartItem
    {
        [Key]
        public Guid ItemId { get; set; }
        public Product Product { get; set; }
        public int Count { get; set; }
        public decimal Cost
        {
            get
            {
                return Product.Cost * Count;
            }
        }
        public Cart Cart { get; set; }
    }
}