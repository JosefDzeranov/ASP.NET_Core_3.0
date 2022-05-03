using System.ComponentModel.DataAnnotations;

namespace OnlineShopWebApp.Models.Attributes
{
    public class DesriptionLengthName : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            Product data = (Product)value;

            if (data.Description.Length < 4)
            {
                ErrorMessage = "Описание слишком короткое";
                return false;
            }
            return true;
        }
    }
}
