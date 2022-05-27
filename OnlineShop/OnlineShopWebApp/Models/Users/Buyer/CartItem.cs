﻿using System.Collections.Generic;
using OnlineShop.Db.Models;

namespace OnlineShopWebApp.Models.Users.Buyer
{
    public class CartItem
    {
        public Product Product { get; set; }
        public int Count { get; set; }
        public List<AdditionalOptions> additionalOptions { get; set; } = new List<AdditionalOptions> { };

        public CartItem()
        {

        }
        public CartItem(Product product)
        {
            Product = product;
            Count = 1;
            additionalOptions.Add(new AdditionalOptions());
        }
        public void UpCount()
        {
            Count++;
            additionalOptions.Add(new AdditionalOptions());
        }

        public void DownCount()
        {
            Count--;
            additionalOptions.RemoveAt(0);
        }

    }
}
