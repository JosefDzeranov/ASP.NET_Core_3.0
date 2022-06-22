using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShopWebApp.Models
{
    public class OrderViewModel
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        
        public string UserId { get; set; }

        public DateTime OrderDateTime { get; set; } = DateTime.Now;

        public CartViewModel Cart { get; set; }

        public OrderStateViewModel State { get; set; } = OrderStateViewModel.Created;

        public List<CartItemViewModel> Items { get; set; }

        public DeliveryInfoViewModel DeliveryInfo { get; set; }

        public decimal CostOrder 
        {
            get
            {
                return Items?.Sum(item => item.Cost) ?? 0; ;
            }
        }
    }
}