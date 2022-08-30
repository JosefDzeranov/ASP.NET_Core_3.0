using System;
using System.Collections.Generic;

namespace Domains
{
    public class Order
    {
        public int Id { get; set; }
        public DeliveryInfo DeliveryInfo { get; set; }
        public List<CartItem> Items { get; set; }
        public OrderStatus Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public decimal? TotalCostWithDiscount { get; set; }

        public Order(List<CartItem> items, DeliveryInfo deliveryInfo)
        {
            CreatedDate = DateTime.Now;
            Items = items;
            DeliveryInfo = deliveryInfo;
            Status = OrderStatus.Processing;
        }

        public Order() { }


    }
}
