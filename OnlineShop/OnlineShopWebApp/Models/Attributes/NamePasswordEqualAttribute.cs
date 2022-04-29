using System.ComponentModel.DataAnnotations;


namespace OnlineShopWebApp.Models.Attributes
{
    /// <summary>
    /// Provides an attribute that compares FirstName/LastName and Password properties.
    /// </summary>
    public class NamePasswordEqualAttribute : ValidationAttribute
    {
        public NamePasswordEqualAttribute()
        {
            ErrorMessage = "The name and password cannot be the same.";
        }

        public override bool IsValid(object value)
        {
            SignUp data = value as SignUp;

            if (data.FirstName == data.Password)
            {
                return false;
            }

            return true;
        }
    }
}
