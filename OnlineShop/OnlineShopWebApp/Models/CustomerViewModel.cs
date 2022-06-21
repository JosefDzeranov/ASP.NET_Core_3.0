using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
namespace OnlineShopWebApp.Models
{
    public class CustomerViewModel
    {
        [Required(ErrorMessage ="Не указано имя")]
        [StringLength(25, MinimumLength =2, ErrorMessage ="Имя должно быть от 2 от 25 симоволов")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Не указана фамилия")]
        [StringLength(25, MinimumLength = 2, ErrorMessage = "Фамилия должна быть от 2 от 25 симоволов")]
        public string Surname { get; set; }
        public int Id { get; set; }
        
        [Required(ErrorMessage ="Не указан email")]
        [EmailAddress(ErrorMessage = "Введите корректный e-mail")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Не указан адрес")]
        public string Adress { get; set; }

        [Required(ErrorMessage = "Не указан телефон")]
        public string Phone { get; set; }
        public string AvatarPath { get; set; }
        public IFormFile UploadedImage { get; set; }

    }
}
