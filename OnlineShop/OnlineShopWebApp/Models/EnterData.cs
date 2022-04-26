using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShopWebApp.Models
{
    public class EnterData
    {
        [Required(ErrorMessage = "Введите логин")]
        string Login { get; set; }

        [Required(ErrorMessage = "Введите пароль")]
        string Password { get; set; }
        bool Remember { get; set; }
    }
}
