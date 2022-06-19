using OnlineShopWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShopWebApp.Models
{
    public class CartViewModel
    {
        public Guid Id;
        public string UserId { get; set; }
        public List<CartItemViewModel> Items { get; set; }
        public decimal Cost
        {
            get
            {
                return Items?.Sum(x => x.Cost) ?? 0;
            }
        }

        public decimal Amount
        {
            get
            {
                return Items?.Sum(x => x.Count) ?? 0;
            }
        }

        public CartViewModel()
        {

        }

        public CartViewModel(string userId)
        {
            Id = Guid.NewGuid();

            UserId = userId;    

            Items = new List<CartItemViewModel>();
        }
    }
}