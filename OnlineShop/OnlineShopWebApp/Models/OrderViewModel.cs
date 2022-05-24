using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShopWebApp.Models
{
    public class OrderViewModel
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public string UserId { get; set; }
        public OrderStatusViewModel Status { get; set; }
        public List<BasketItemViewModel> Items { get; set; }
        public DeliveryInfoViewModel DeliveryInfo { get; set; }

        public decimal TotalCost
        {
            get
            {
                return Items?.Sum(item => item.Cost) ?? 0;
            }
        }
    }
}
