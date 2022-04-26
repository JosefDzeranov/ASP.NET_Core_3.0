using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShopWebApp.Models
{
    public class RegistrationData
    {
        [Required(ErrorMessage = "Поле обязательно к заполнению")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Поле обязательно к заполнению")]
        [Range(18, 110, ErrorMessage ="Недопустимый возраст")]
        public string Age { get; set; }

        [Required(ErrorMessage = "Поле обязательно к заполнению")]
        [EmailAddress(ErrorMessage = "Некорректный адрес")]

        public string Email { get; set; }

        [Required(ErrorMessage = "Поле обязательно к заполнению")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Поле обязательно к заполнению")]
        public string Password1 { get; set; }

        [Required(ErrorMessage = "Поле обязательно к заполнению")]
        [Compare("Password1", ErrorMessage = "Пароли не совпадают")]
        public string Password2 { get; set; }
    }
}
