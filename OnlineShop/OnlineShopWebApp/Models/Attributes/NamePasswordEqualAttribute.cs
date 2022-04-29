using System.ComponentModel.DataAnnotations;

namespace OnlineShopWebApp.Models.Attributes
{
    /// <summary>
    /// Provides an attribute that compares FirstName/LastName and Password fields.
    /// </summary>
    public class NamePasswordEqualAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            SignUp data = (SignUp)value;

            if (data.FirstName == data.Password)
            {
                ErrorMessage = "The FirstName and password cannot be the same.";
                return false;
            }

            if (data.LastName == data.Password)
            {
                ErrorMessage = "The LastName and password cannot be the same.";
                return false;
            }
            return true;
        }
    }
}
