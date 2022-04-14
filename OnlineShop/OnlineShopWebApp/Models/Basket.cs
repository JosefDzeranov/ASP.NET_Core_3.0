using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShopWebApp.Models
{
    public class Basket
    {
        public Guid Id { get; set; }
        public string UserId { get; set; }
        public List<BasketItem> Items { get; set; }
        public decimal TotalCost 
        {
            get { return Items.Sum(item => item.Cost); }
        }

        public Basket(string userId)
        {
            Id = Guid.NewGuid();
            UserId = userId;
            Items = new List<BasketItem>();
        }
    }
}
