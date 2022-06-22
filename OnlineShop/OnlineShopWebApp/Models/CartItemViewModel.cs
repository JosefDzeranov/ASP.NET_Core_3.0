using OnlineShop.Db.Models;
using System;

namespace OnlineShopWebApp.Models
{
    public class CartItemViewModel
    {
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
        //public CartViewModel Cart { get; set; }
    }
}