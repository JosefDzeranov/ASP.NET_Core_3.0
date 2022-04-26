using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopWebApp.Models
{
    public class User
    {
        public User(string id, string name, string phone)
        {
            Id = id;
            Name = name;
            Phone = phone;
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }


    }
}
