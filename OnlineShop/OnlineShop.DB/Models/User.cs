using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.DB.Models
{
    public class User : IdentityUser
    {
        public  string FirstName {get; set; }
        public string LastName {get; set; }
        public string AvatarPath { get; set; }
    }
}
