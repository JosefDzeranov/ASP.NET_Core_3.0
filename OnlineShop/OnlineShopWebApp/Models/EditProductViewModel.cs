using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OnlineShopWebApp.Models
{
    public class EditProductViewModel
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
        public List<string> ImagesPaths { get; set; }
        public List<IFormFile> UploadedFiles { get; set; }
    }
}
