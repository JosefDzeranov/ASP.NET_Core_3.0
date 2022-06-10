using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OnlineShopWebApp.Models
{
    public class EditProductViewModel
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Название не заполнено")]
        [StringLength(25, MinimumLength = 2, ErrorMessage = "название должно быть от 2 до 25 символов")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Цена должна быть указана")]
        [Range(typeof(decimal), "25.00", "50000.00")]
        public decimal Cost { get; set; }
        public string Description { get; set; }
        public List<string> ImagesPaths { get; set; }
        public string MainImagePath
        {
            get
            {
                return ImagesPaths.Count == 0 ? "/images/book.png" : ImagesPaths[0];
            }
        }
        public List<IFormFile> UploadedImages { get; set; }
    }
}
