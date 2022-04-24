using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShopWebApp.Models
{
    public class RegistrationData
    {
        public string Login { get; set; }
        public string Password1 { get; set; }
        public string Password2 { get; set; }
    }
}
