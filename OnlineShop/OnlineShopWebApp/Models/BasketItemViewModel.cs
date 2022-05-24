using System;
using OnlineShop.Db.Models;

namespace OnlineShopWebApp.Models
{
    public class BasketItemViewModel
    {
        public Guid Id { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public decimal Cost
        {
            get { return Product.Cost * Quantity; }
        }

    }
}
