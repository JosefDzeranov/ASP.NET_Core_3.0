﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShopWebApp.Models
{
    public class Order
    {
        public Guid Id { get; set; }
        public User User { get; set; }
        public Cart Cart { get; set; }
        public string State { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
    }
}
