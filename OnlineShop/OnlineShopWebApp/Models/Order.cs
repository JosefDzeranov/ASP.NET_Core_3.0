using System;
using System.Collections.Generic;

namespace OnlineShopWebApp.Models
{
    public class Order
    {
        public Guid Id { get; set; }
        public UserDeliveryInfo User { get; set; }
        public List<CartItem> Items { get; set; }

        public Order()
        {
            Id = Guid.NewGuid();
        }
    }
}
