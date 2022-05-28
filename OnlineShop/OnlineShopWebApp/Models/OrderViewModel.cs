using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShopWebApp.Models
{
    public class OrderViewModel
    {
        public Guid Id { get; set; }
        public DeliveryInformationViewModel DeliveryInformation { get; set; }
        public CartViewModel Cart { get; set; }
        public OrderStateViewModel State { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }

        public OrderViewModel()
        {
            State = OrderStateViewModel.Created;
        }
    }
}
