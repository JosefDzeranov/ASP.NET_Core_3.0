using System;

namespace OnlineShopWebApp.Models
{
    public class Order
    {
        public Guid Id { get; set; }
        public Cart Cart { get; set; }
        public DeliveryInfo DeliveryInfo { get; }
        public DateTime CreatedDate { get; set; }


        public Order(Cart cart, DeliveryInfo deliveryInfo)
        {
            Id = Guid.NewGuid();
            CreatedDate = DateTime.Now;
            Cart = cart;
            DeliveryInfo = deliveryInfo;
        }
    }
}
