using System;

namespace OnlineShopWebApp.Models
{
    public class Order
    {
        public int Id { get; set; }
        public Cart Cart { get; set; }
        public DeliveryInfo DeliveryInfo { get; }
        public OrderStatus Status { get; set; }
        public DateTime CreatedDate { get; set; }

        public Order(Cart cart, DeliveryInfo deliveryInfo)
        {
            CreatedDate = DateTime.Now;
            Cart = cart;
            DeliveryInfo = deliveryInfo;
            Status = OrderStatus.Processing;
        }


    }
}
