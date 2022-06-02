using OnlineShop.DB.Models;
using System;

namespace OnlineShopWebApp.Models
{
    public class CartItemViewModel
    {
        public Guid Id { get; set; }
        public ProductViewModel ProductViewModel { get; set; }
        public int Amount { get; set; }
        public Cart Cart { get; set; }


        public decimal Cost
        {
            get { return ProductViewModel.Cost*Amount; }
        }
    }
}
