using OnlineShop.Db.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.Db.Models
{
    public class Order
    {
        public Guid Id { get; set; }
        public DeliveryInformation DeliveryInformation { get; set; }
        public Cart Cart { get; set; }
        public OrderState State { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }

        public Order()
        {
            State = OrderState.Created;
        }
    }
}
