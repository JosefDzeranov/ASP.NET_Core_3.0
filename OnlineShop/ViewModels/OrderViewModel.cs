using System;
using System.Collections.Generic;

namespace ViewModels
{
    public class OrderViewModel
    {
        public int Id { get; set; }
        public List<CartItemViewModel> Items { get; set; }
        public DeliveryInfoModelView DeliveryInfo { get; set; }
        public OrderStatusViewModel Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public decimal? TotalCostWithDiscount { get; set; }

        public OrderViewModel(List<CartItemViewModel> items, DeliveryInfoModelView deliveryInfo)
        {

            CreatedDate = DateTime.Now;
            Items = items;
            DeliveryInfo = deliveryInfo;
            Status = OrderStatusViewModel.Processing;
        }

        public OrderViewModel() { }

    }
}
