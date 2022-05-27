using System.ComponentModel.DataAnnotations;

namespace OnlineShopWebApp.Models
{
    public class DeliveryInformationViewModel
    {
        [Required(ErrorMessage = "Введите имя")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Введите адрес")]
        public string Adress { get; set; }

        [Required(ErrorMessage = "Введите номер телефона")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Введите e-mail")]
        [EmailAddress(ErrorMessage = "Некорректный адрес")]
        public string Email { get; set; }
    }
}
