using System.ComponentModel.DataAnnotations;

namespace OnlineShopWebApp.Models
{
    public class EnterData
    {
        [Required(ErrorMessage = "Введите логин")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Введите пароль")]
        public string Password { get; set; }
        public bool Remember { get; set; }
        public string ReturnUrl { get; set; }
    }
}
