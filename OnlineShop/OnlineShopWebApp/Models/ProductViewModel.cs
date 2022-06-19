using OnlineShop.Db.Models;
using System;
using System.Collections.Generic;

namespace OnlineShopWebApp.Db.Models
{
    public class ProductViewModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public decimal Cost { get; set; }

        public string Description { get; set; }

        public string ImagePath { get; set; }

        public List<CartItemViewModel> CartItems { get; set; }

        public ProductViewModel()
        {
            CartItems = new List<CartItemViewModel>();
        }
    }
}