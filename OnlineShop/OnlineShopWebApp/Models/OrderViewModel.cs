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
        public string UserId { get; set; }
        public List<CartItemViewModel> Items { get; set; }
        public decimal FullCost
        {
            get
            {
                return Items?.Sum(x => x.Cost) ?? 0;
            }
        }

        public decimal Amount
        {
            get
            {
                return Items?.Sum(x => x.Amount) ?? 0;
            }
        }

        public OrderViewModel()
        {
            State = OrderStateViewModel.Created;
        }
    }
}
