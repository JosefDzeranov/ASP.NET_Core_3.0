﻿using System;
using System.ComponentModel.DataAnnotations;

namespace OnlineShopWebApp.Models
{
    public class Registration
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required(ErrorMessage ="Не указан логин")]
        [EmailAddress]
        public string Login { get; set; }

        [Required]
        [Phone]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Не указан пароль")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Не указан повторный пароль")]
        [Compare("Password", ErrorMessage = "пароли не совпадают")]
        public string ConfirmedPassword { get; set; }

        public string ReturnUrl { get; set; }

        public Registration()
        {
            Id = Guid.NewGuid();
        }
    }
}
