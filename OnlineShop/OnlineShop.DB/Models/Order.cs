using System;
using System.Collections.Generic;

namespace OnlineShop.DB.Models
{
    public class Order
    {
        public int Id { get; set; }
        public DeliveryInfo DeliveryInfo { get; set; }
        public List<Cart> Carts { get; set; } = new List<Cart>();
        public OrderStatus Status { get; set; }
        public DateTime CreatedDate { get; set; }

        public Order(Cart cart, DeliveryInfo deliveryInfo)
        {
            CreatedDate = DateTime.Now;
            Carts.Add(cart);
            DeliveryInfo = deliveryInfo;
            Status = OrderStatus.Processing;
        }

        public Order() { }


    }
}
