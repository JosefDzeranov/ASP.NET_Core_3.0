using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShopWebApp.Models
{
    public class Customer 
    {
        public Guid Id { get; set; }

        public string UserId { get; set; }

        public string LastName { get; set; }

        public string Name { get; set; }

        public string PhoneMobile { get; set; }

        public string Mail { get; set; }

        public string Address { get; set; }

        public Customer(string userId, string name, string lastname, string email, string adress, string phone)
        {
            UserId = userId;
            Name = name;
            LastName = lastname;
            Id = new Guid();
            Mail = email;
            Address = adress;
            PhoneMobile = phone;
        }
    }
}