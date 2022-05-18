using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShopWebApp.Models
{
    public class BasketViewModel
    {
        public Guid Id { get; set; }
        public string UserId { get; set; }
        public List<BasketItemViewModel> Items { get; set; }
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

        public BasketViewModel() { } //Empty ctor for XML serializing.
        public BasketViewModel(string userId)
        {
            Id = Guid.NewGuid();
            UserId = userId;
            Items = new List<BasketItemViewModel>();
        }
    }
}
