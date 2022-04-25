using System.Collections.Generic;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Models
{
    public class User
    {
        public int Id { get; set; }
        public string login { get; set; }
        public string Fistname { get; set; }
        public string Secondname { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

    }
}
