using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShopWebApp.Models
{
    public class Order
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }

        public override string ToString()
        {
            return $"{Name}{Constants.Separator}{Phone}{Constants.Separator}{Email}{Constants.Separator}{Address}";
        }
    }

    
}
