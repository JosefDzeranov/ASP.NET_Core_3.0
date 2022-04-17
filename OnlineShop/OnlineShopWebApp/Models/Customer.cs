using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShopWebApp.Models
{
    public class Customer 
    {
        public Guid Id { get; set; }

        public string LastName { get; set; }

        public string Name { get; set; }

        public string Phone { get; set; }

        public string Mail { get; set; }

        public string Address { get; set; }

        //public Customer(string name, string lastname, string email, string adress, string phone)
        //{
        //    Id = new Guid();
        //    LastName = lastname;
        //    Name = name;
        //    Phone = phone;
        //    Mail = email;
        //    Address = adress;
        //}
    }
}