using System.ComponentModel.DataAnnotations;

namespace OnlineShopWebApp.Models
{
    public class UserDeliveryInfo
    {
        [Required(ErrorMessage = "Введите имя")]
        public string InputName { get; set; }
        [Required]
        public string InputLastName { get; set; }
        [Required(ErrorMessage = "Введите фамилия")]
        public string InputCity { get; set; }
        [Required(ErrorMessage = "Введите город")]
        public string InputAddress { get; set; }
        [Required(ErrorMessage = "Введите адрес")]
        public string InputEmail { get; set; }
    }
}
