using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShopWebApp.Models
{
    public class Order
    {
        private static int constantCounter = 1;
        public int Id { get; set; }
        public User User { get; set; }
        public Cart Cart { get; set; }
        public string State { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public EnterData EnterData { get; set; }

        public Order()
        {
            Id = constantCounter;
            constantCounter++;
        }
    }
}
