using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;

namespace OnlineShopWebApp.Models
{
    public class ProductViewModel
    {
        public Guid Id { get; set; }
            
        [Required(ErrorMessage = "Введите название книги")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Введите стоимость")]
        public decimal Cost { get; set; }

        [Required(ErrorMessage = "Введите описание")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Введите количество страниц")]
        public int Pages { get; set; }
        public string ImagePath { get; set; }
        public IFormFile UploadedFile { get; set; }
    }
}
