using System.ComponentModel.DataAnnotations;

namespace OnlineShopWebApp.Areas.Admin.Models.Attributes
{
    public class EditNamePasswordEqualAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            ChangePassword data = (ChangePassword)value;

            if (data.FirstName == data.Password)
            {
                ErrorMessage = "Имя и пароль не могут совпадать";
                return false;
            }

            if (data.LastName == data.Password)
            {
                ErrorMessage = "Фамилия и пароль не могут совпадать";
                return false;
            }
            return true;
        }
    }
}