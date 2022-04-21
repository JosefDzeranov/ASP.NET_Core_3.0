using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShopWebApp.Models
{
    public class Delivery
    {
        public Address Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        public Delivery () { } // Empty ctor for XML serializing.
    }
}
