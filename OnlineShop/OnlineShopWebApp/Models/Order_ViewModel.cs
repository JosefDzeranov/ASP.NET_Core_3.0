using System;
using System.Collections.Generic;
using System.Linq;
using OnlineShop.Db.Models;

namespace OnlineShopWebApp.Models
{
    public class Order_ViewModels
    {
        public Guid Id { get; set; }
        public List<CartItem> CartItem { get; set; }
        public UserDeleveryInfo UserDeleveryInfo { get; set; }
        public DateTime CreateDateTime { get; set; }
        public OrderStatus Status { get; set; }
        public string BuyerLogin { get; set; }

        public decimal FullCost
        {
            get
            {
                return FullCost;
            }
            set
            {
                FullCost = CartItem?.Sum(x => x.Cost) ?? 0;
            }
        }

        public Order_ViewModels()
        {
            CreateDateTime = DateTime.UtcNow;
            Status = OrderStatus.Created;
        }


            
    }
}
