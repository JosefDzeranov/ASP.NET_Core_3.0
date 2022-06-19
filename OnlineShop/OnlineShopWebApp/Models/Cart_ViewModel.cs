using System;
using System.Collections.Generic;
using OnlineShop.Db.Models;

namespace OnlineShopWebApp.Models
{
    public class Cart_ViewModel
    {
        public Guid Id { get; set; }
        public string BuyerLogin { get; set; }

        public List<CartItem> CartItems { get; set; }

        public UserDeleveryInfo UserDeleveryInfo { get; set; } = new UserDeleveryInfo();

        public DateTime CreateDateTime { get; set; }

        public decimal FullSumm()
        {
            decimal fullSumm = 0;
            foreach (var cartItem in CartItems)
            {
                fullSumm += cartItem.Count * cartItem.Product.Cost;
            }
            return fullSumm;
        }

    }
}
