using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShopWebApp.Models
{
    public class Customer
    {
        public Guid Id { get; }

        public string LastName { get; set; }

        public string Name { get; set; }

        public List<Contacts> Contacts { get; set; }
    }
}