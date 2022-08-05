using System.ComponentModel.DataAnnotations;

namespace ViewModels.Attributes
{
    public class NamePasswordAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            Registration data = (Registration)value;

            if (data.Login == data.Password)
            {
                ErrorMessage = "Пароль и логин не должны совпадать";
                return false;
            }
            return true;
        }
    }
}
