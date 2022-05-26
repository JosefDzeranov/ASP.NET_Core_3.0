﻿using System;
using System.Collections.Generic;

namespace OnlineShop.Db.Models
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Cost { get; set; }
        public string Description { get; set; }
        public int Pages { get; set; }
        public List<CartItem> CartItems { get; set; }
        public ICollection<Favourite> Favourites { get; set; }
        public List<FavouriteProducts> FavouriteProducts { get; set; } = new List<FavouriteProducts>();
        public Product()
        {
            CartItems = new List<CartItem>();
            Favourites = new List<Favourite>();
        }
    }
}
