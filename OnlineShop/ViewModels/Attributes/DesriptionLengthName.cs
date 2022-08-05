using System.ComponentModel.DataAnnotations;

namespace ViewModels.Attributes
{
    public class DesriptionLengthName : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            ProductViewModel data = (ProductViewModel)value;

            if (data.Description.Length < 4)
            {
                ErrorMessage = "Описание слишком короткое";
                return false;
            }
            return true;
        }
    }
}
