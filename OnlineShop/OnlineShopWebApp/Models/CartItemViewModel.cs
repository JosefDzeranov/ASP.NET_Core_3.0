using OnlineShopWebApp.Db.Models;
using System;

namespace OnlineShop.Db.Models
{
    public class CartItemViewModel
    {
        public Guid ItemId { get; set; }
        public ProductViewModel Product { get; set; }
        public int Count { get; set; }
        public decimal Cost
        {
            get
            {
                return Product.Cost * Count;
            }
        }
    }
}