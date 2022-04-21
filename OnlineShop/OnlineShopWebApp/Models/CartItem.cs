﻿using System;

namespace OnlineShopWebApp.Models
{
    public class CartItem
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
    }
}