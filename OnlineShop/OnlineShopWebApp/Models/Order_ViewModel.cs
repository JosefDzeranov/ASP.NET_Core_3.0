using System;
using System.Collections.Generic;
using System.Linq;
using OnlineShop.Db.Models;

namespace OnlineShopWebApp.Models
{
    public class Order_ViewModels
    {
        public Guid Id { get; set; }
        public List<CartItem> CartItems { get; set; }
        public UserDeleveryInfo UserDeleveryInfo { get; set; }
        public DateTime CreateDateTime { get; set; }
        public OrderStatus Status { get; set; }
        public string BuyerLogin { get; set; }
        public decimal FullCost()
        {
            decimal fullCost = 0;
            foreach (var cartItem in CartItems)
            {
                fullCost += cartItem.Product.Cost * cartItem.Count;
            }
            return fullCost;
        }

    }
}
