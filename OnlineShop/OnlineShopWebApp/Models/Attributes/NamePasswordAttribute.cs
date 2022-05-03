using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopWebApp.Models.Attributes
{
    public class NamePasswordAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            Registration data = (Registration)value;

            if (data.Name == data.Password)
            {
                ErrorMessage = "Пароль и логин не должны совпадать";
                return false;
            }
            return true;
        }
    }
}
