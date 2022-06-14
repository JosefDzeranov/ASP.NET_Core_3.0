using System;
using System.ComponentModel.DataAnnotations;

namespace OnlineShopWebApp.Models
{
    public class Product_ViewModel
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Не указан шифр")]
        public string CodeNumber { get; set; }

        [Required(ErrorMessage = "Не указана стоймость")]
        [Range(1, 10000000000D, ErrorMessage = "Слишком маленькое значение")]
        public decimal Cost { get; set; }

        [Required(ErrorMessage = "Не указана площадь")]
        [Range(1, 10000000000D, ErrorMessage = "Слишком маленькое значение")]
        public double Square { get; set; }

        [Required(ErrorMessage = "Не указана ширина")]
        [Range(1, 10000000000D, ErrorMessage = "Слишком маленькое значение")]
        public double Width { get; set; }

        [Required(ErrorMessage = "Не указана длина")]
        [Range(1, 10000000000D, ErrorMessage = "Слишком маленькое значение")]
        public double Length { get; set; }

        [Required(ErrorMessage = "Не указано описание")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Не указано изображение")]
        public string Images { get; set; }

        
    }
}
