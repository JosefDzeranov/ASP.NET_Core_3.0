using System.ComponentModel.DataAnnotations;


namespace ViewModels.Attributes
{
    public class RegistrLengthName : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            Registration data = (Registration)value;

            if (data.Login.Length < 4)
            {
                ErrorMessage = "Имя должно быть не короче 4-х символов";
                return false;
            }
            return true;
        }
    }
}
