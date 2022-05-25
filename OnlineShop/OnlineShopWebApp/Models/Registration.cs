using System.ComponentModel.DataAnnotations;

namespace OnlineShopWebApp.Models
{
    public class Registration
    {
        public string InputName { get; set; }
        public string InputLastName { get; set; }
        public string InputEmail1 { get; set; }
        public string InputPassword { get; set; }
        //[Required]
        //[Compare("InputPassword", ErrorMessage = "Пароль не совпадают!")]
        //[DataType(DataType.Password)]
        public bool InputConfirmPassword { get; set; }
        public bool exampleCheck1 { get; set; }
    }
}
