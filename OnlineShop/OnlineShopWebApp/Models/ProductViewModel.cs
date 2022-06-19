using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OnlineShopWebApp.Models
{
    public class ProductViewModel
    {
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public decimal Cost { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string ImagePath { get; set; }

        //public List<CartItemViewModel> CartItems { get; set; }

        //public ProductViewModel()
        //{
        //    CartItems = new List<CartItemViewModel>();
        //}
    }
}