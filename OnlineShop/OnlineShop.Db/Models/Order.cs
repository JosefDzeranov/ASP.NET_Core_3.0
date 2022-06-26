using System;
using System.Collections.Generic;

namespace OnlineShop.Db.Models
{
    public class Order
    {
        public Guid Id { get; set; }
        public List<CartItem> CartItems { get; set; }
        public UserDeleveryInfo UserDeleveryInfo { get; set; }
        public DateTime CreateDateTime { get; set; }
        public OrderStatus Status { get; set; }
        public string BuyerLogin { get; set; }

        public Order()
        {
            CreateDateTime = DateTime.UtcNow;
            Status = OrderStatus.Created;
        }
    }
}
