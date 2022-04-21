using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShopWebApp.Models
{
    public class Contacts
    {
        public Guid Id { get; }

        public string Phone { get; set; }

        public string Mail { get; set; }

        public string Address { get; set; }
    }
}