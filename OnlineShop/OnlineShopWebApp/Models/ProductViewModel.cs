using System;
using System.ComponentModel.DataAnnotations;

namespace OnlineShopWebApp.Models
{
    public class ProductViewModel
    {
        
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Название не заполнено")]
        [StringLength(25, MinimumLength = 2, ErrorMessage = "название должно быть от 2 до 25 символов")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Цена должна быть указана")]
        [Range(typeof(decimal), "25,0", "50000,0")]
        public decimal Cost { get; set; }
        public string Description { get; set; }
        [Required(ErrorMessage = "Фото должно быть добавлено")]
        public string ImgPath { get; set; }

    }
}
