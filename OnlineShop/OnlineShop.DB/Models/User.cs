﻿using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace OnlineShop.DB.Models
{
    public class User : IdentityUser
    {
        public string Login { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public User(string login)
        {
            Login = login;
        }
        public User() { }


    }
}
