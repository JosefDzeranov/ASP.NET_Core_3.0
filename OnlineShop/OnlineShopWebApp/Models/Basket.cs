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
            get
            {
                return Items?.Sum(item => item.Cost) ?? 0;
            }
        }
        public int TotalQuantity
        {
            get
            {
                return Items?.Sum(item => item.Quantity) ?? 0;
            }
        }

        public Basket() { } //Empty ctor for XML serializing.
        public Basket(string userId)
        {
            Id = Guid.NewGuid();
            UserId = userId;
            Items = new List<BasketItem>();
        }
    }
}
