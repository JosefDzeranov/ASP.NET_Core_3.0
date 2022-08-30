using System;
using System.Collections.Generic;

namespace Entities
{
    public class OrderEntity
    {
        public int Id { get; set; }
        public DeliveryInfoEntity DeliveryInfo { get; set; }
        public List<CartItemEntity>? Items { get; set; }
        public OrderStatusEntity Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public decimal? TotalCostWithDiscount { get; set; }

        public OrderEntity(List<CartItemEntity> items, DeliveryInfoEntity deliveryInfo)
        {
            CreatedDate = DateTime.Now;
            Items = items;
            DeliveryInfo = deliveryInfo;
            Status = OrderStatusEntity.Processing;
        }

        public OrderEntity() { }


    }
}
