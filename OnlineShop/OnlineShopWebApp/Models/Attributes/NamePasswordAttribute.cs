using System.ComponentModel.DataAnnotations;

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
