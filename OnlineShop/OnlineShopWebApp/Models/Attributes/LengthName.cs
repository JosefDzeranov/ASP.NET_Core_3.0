using System.ComponentModel.DataAnnotations;


namespace OnlineShopWebApp.Models.Attributes
{
    public class LengthName : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            Registration data = (Registration)value;

            if (data.Name.Length < 4)
            {
                ErrorMessage = "Имя должно быть не короче 4-х символов";
                return false;
            }
            return true;
        }
    }
}
