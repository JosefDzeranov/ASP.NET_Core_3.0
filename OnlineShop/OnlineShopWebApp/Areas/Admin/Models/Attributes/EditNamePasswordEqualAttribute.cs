using System.ComponentModel.DataAnnotations;

namespace OnlineShopWebApp.Areas.Admin.Models.Attributes
{
    public class EditNamePasswordEqualAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            ChangePasswordViewModel data = (ChangePasswordViewModel)value;

            if (data.FirstName == data.NewPassword)

                if (data.FirstName == data.NewPassword)
            {
                ErrorMessage = "Имя и пароль не могут совпадать";
                return false;
            }

            if (data.LastName == data.NewPassword)
            {
                ErrorMessage = "Фамилия и пароль не могут совпадать";
                return false;
            }
            return true;
        }
    }
}