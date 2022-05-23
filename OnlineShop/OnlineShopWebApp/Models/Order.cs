using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShopWebApp.Models
{
    public class Order
    {
        public Guid Id { get; set; }
        public DeliveryInformarion DeliveryInformarion { get; set; }
        public CartViewModel Cart { get; set; }
        public OrderState State { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }

        public Order()
        {
            State = OrderState.Created;
        }
    }
}
