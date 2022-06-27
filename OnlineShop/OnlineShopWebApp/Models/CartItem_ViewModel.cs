using System;
using OnlineShop.Db.Models;

namespace OnlineShopWebApp.Models
{
    public class CartItem_ViewModel
    {
        public Guid Id { get; set; }
        public Product Product { get; set; }
        public int Count { get; set; }
        private decimal cost { get; set; }

        public decimal Cost
        {
            get
            {
                return cost;
            }
            set
            {
                cost = Product.Cost * Count;
            }
        }
    }
}
