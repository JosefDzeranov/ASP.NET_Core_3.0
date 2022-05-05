﻿using System;
using System.ComponentModel.DataAnnotations;

namespace OnlineShopWebApp.Models
{
    public class User
    {
        [Required]
        public Guid Id { get; set; } = Guid.NewGuid();
        [Required]
        public string Name { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Email { get; set; }
        public bool RememberMe { get; set; }
        public bool IsAdmin { get; set; }

    }
}
